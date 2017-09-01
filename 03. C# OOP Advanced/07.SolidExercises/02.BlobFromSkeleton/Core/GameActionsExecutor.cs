namespace _02.BlobFromSkeleton.Core
{
    using Contracts;
    using Contracts.IO;
    using Models;
    using Models.Attacks.Factory;
    using Models.Behaviours.Factory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameActionsExecutor
    {
        private BehaviourFactory behaviourFactory;
        private AttackFactory attackFactory;
        private IDictionary<string, Blob> blobs;

        public GameActionsExecutor()
        {
            this.behaviourFactory = new BehaviourFactory();
            this.attackFactory = new AttackFactory();
            this.blobs = new Dictionary<string, Blob>();
        }

        public void PlayAction(string input, IWriter writer)
        {
            IList<string> inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string action = inputArgs[0];
            inputArgs.RemoveAt(0);

            switch (action)
            {
                case "create":
                    this.CreateBlob(inputArgs);
                    break;

                case "attack":
                    this.Attack(inputArgs);
                    break;

                case "status":
                    this.GetStatus(writer);
                    break;
            }

            this.RollTurn();
        }

        private void CreateBlob(IList<string> inputArgs)
        {
            string name = inputArgs[0];
            int health = int.Parse(inputArgs[1]);
            int damage = int.Parse(inputArgs[2]);
            IBehaviour behaviour = this.behaviourFactory.CreateBehaviour(inputArgs[3]);
            IAttack attack = this.attackFactory.CreateAttack(inputArgs[4]);

            this.blobs.Add(name, new Blob(name, health, damage, behaviour, attack));
        }

        private void Attack(IList<string> inputArgs)
        {
            string attackerName = inputArgs[0];
            string targetName = inputArgs[1];

            Blob attacker = this.blobs[attackerName];
            Blob target = this.blobs[targetName];

            attacker.Attack(target);
        }

        private void GetStatus(IWriter writer)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Blob blob in this.blobs.Values)
            {
                sb.AppendLine(blob.ToString());
            }

            writer.WriteLine(sb.ToString().Trim());
        }

        private void RollTurn()
        {
            foreach (Blob blob in this.blobs.Values)
            {
                blob.MoveToNextTurn();
            }
        }
    }
}