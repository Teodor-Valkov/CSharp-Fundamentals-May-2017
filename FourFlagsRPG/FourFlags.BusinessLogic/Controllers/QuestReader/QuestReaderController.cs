﻿namespace FourFlags.BusinessLogic.Controllers.Quest
{
    using FourFlags.Models.Factories;
    using FourFlagsRPG.Models.Contracts.Enemies;
    using FourFlagsRPG.Models.Contracts.Items;
    using FourFlagsRPG.Models.Contracts.Quests;
    using FourFlagsRPG.Models.Enums;
    using FourFlagsRPG.Models.Exceptions.Quest_Exceptions;
    using FourFlagsRPG.Models.Factories;
    using FourFlagsRPG.Models.IO;
    using FourFlagsRPG.Models.Models.Enemies;
    using FourFlagsRPG.Models.Models.Items;
    using FourFlagsRPG.Models.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class QuestReaderController
    {
        private List<IQuest> quests;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private FileWriter fileWriter;
        private FileReader fileReader;

        public QuestReaderController(FileWriter fileWriter, FileReader fileReader)
        {
            this.quests = new List<IQuest>();
            this.enemies = new List<IEnemy>();
            this.items = new List<IItem>();
            this.fileWriter = fileWriter;
            this.fileReader = fileReader;

            this.InitializeQuests();
        }

        public IReadOnlyList<IQuest> Quests
        {
            get { return this.quests.AsReadOnly(); }
        }

        public void InitializeQuests()
        {
            this.InitializeEnemies();
            this.InitializeItems();

            // Get Quest Directory
            string directory = this.GetQuestDirectory();

            // Read Quest Files from Directory;
            this.ReadQuests(directory);
        }

        private void ReadQuests(string directory)
        {
            Regex regex = new Regex(QuestReaderConstants.QuestReaderPattern);
            string[] allQuests = this.GetQuestNames(directory);
            string questArgs = string.Empty;

            for (int i = 0; i < allQuests.Length; i++)
            {
                questArgs = this.fileReader.ReadToEnd(allQuests[i]);

                Match match = regex.Match(questArgs);

                string name = match.Groups[2].ToString().Trim();
                string description = match.Groups[3].ToString().Trim();
                string destination = match.Groups[4].ToString().Trim();
                string enviroment = match.Groups[5].ToString().Trim();
                string progress = match.Groups[6].ToString();
                string itemRewards = match.Groups[7].ToString();
                int experienceReward = int.Parse(match.Groups[8].ToString().Trim());

                IQuest currentQuest = QuestFactory.CreateQuest(i + 1, name, description, destination, enviroment, experienceReward, this.GetEnemies(progress), this.GetItems(itemRewards));

                this.quests.Add(currentQuest);
            }
        }

        private string GetQuestDirectory()
        {
            // Get Main Directory
            Type type = Type.GetType(this.ToString());
            string projectName = type.Namespace.Split('.').First();
            string currentDirectory = Directory.GetCurrentDirectory();
            int indexOfFolderInString = currentDirectory.LastIndexOf(projectName, StringComparison.Ordinal);
            string directory = currentDirectory.Substring(0, indexOfFolderInString);

            // Go to Quests Folder(Create if non-existant)
            string[] allDirectories = Directory.GetDirectories(directory);
            bool createHelpFile = false;

            if (allDirectories.All(d => d != QuestReaderConstants.QuestDirectoryName))
            {
                Directory.CreateDirectory(string.Format(QuestReaderConstants.CreateQuestDirectory, directory));
                createHelpFile = true;
            }

            directory = string.Format(QuestReaderConstants.CreateQuestDirectoryPath, directory);

            if (createHelpFile)
            {
                CreateHelpFIle(directory);
            }

            return directory;
        }

        private string[] GetQuestNames(string directory)
        {
            return Directory.GetFiles(directory).Where(f => f.EndsWith(QuestReaderConstants.QuestFileNameEnding)).ToArray();
        }

        private List<IItem> GetItems(string ids)
        {
            List<IItem> itemRewards = new List<IItem>();

            int[] allItemIDs = this.GetIDs(ids);

            foreach (int itemID in allItemIDs)
            {
                IItem item = this.items.FirstOrDefault(i => i.Id == itemID);

                if (item != null)
                {
                    itemRewards.Add(item);
                }
            }

            return itemRewards.Distinct().ToList();
        }

        private List<IEnemy> GetEnemies(string ids)
        {
            List<IEnemy> enemies = new List<IEnemy>();

            int[] allEnemyIDs = this.GetIDs(ids);

            foreach (int enemyId in allEnemyIDs)
            {
                IEnemy enemy = this.enemies.FirstOrDefault(i => i.Id == enemyId);

                if (enemy == null)
                {
                    throw new InvalidEnemyException();
                }

                enemies.Add(enemy);
            }

            return enemies.ToList();
        }

        private int[] GetIDs(string IDString)
        {
            return IDString.Split(new[] { " ", ",", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        private void CreateHelpFIle(string directory)
        {
            string helpText = QuestReaderConstants.CreateHelpTextFile;
            this.fileWriter.Write(helpText, directory, QuestReaderConstants.HelpTextFileName);
        }

        private void InitializeEnemies()
        {
            List<Type> enemiesAssembly = Assembly.GetAssembly(typeof(Enemy)).GetTypes()
                .Where(t => t.Namespace == QuestReaderConstants.EnemiesNamespace && !t.IsAbstract)
                .ToList();

            for (int i = 0; i < enemiesAssembly.Count; i++)
            {
                Enemies enemyEnumType = (Enemies)Enum.Parse(typeof(Enemies), enemiesAssembly[i].Name);
                this.enemies.Add(EnemyFactory.CreateEnemy(enemyEnumType, i + 1));
            }
        }

        private void InitializeItems()
        {
            List<Type> items = Assembly.GetAssembly(typeof(Item)).GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IItem)) && !t.IsAbstract)
                .ToList();

            for (int i = 0; i < items.Count; i++)
            {
                this.items.Add(ItemFactory.CreateItem(items[i].Name, i + 1));
            }
        }
    }
}