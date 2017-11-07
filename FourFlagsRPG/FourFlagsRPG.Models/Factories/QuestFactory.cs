using FourFlagsRPG.Models.Contracts.Enemies;
using FourFlagsRPG.Models.Contracts.Items;
using FourFlagsRPG.Models.Contracts.Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FourFlagsRPG.Models.Factories
{
    public static class QuestFactory
    {
        private const string HuntQuestName = "HuntQuest";

        public static IQuest CreateQuest(int id, string name, string description, string destination, string enviroment, int experienceReward, ICollection<IEnemy> enemiesToKill, ICollection<IItem> itemRewards)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.DefinedTypes
                .FirstOrDefault(t => t.Name == HuntQuestName);

            return (IQuest)Activator.CreateInstance(type, new object[] { id, name, description, description, enviroment, experienceReward, enemiesToKill, itemRewards });
        }
    }
}