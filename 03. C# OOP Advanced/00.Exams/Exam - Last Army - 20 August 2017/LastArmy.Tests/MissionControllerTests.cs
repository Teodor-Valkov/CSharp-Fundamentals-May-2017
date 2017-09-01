using NUnit.Framework;

namespace LastArmy.Tests
{
    [TestFixture]
    public class MissionControllerTests
    {
        private MissionController ms;

        [SetUp]
        public void Initialize()
        {
            this.ms = new MissionController(new Army(), new WareHouse());
        }

        // The test 'TestDeclineOldestMissionInQueue()' is the only one that covers the third Test in Judge
        // The tests for returning 'mission on hold' and returning 'mission completed' are the other needed Tests for Judge

        [Test]
        public void TestEasyMissionOnHold()
        {
            IMission mission = new Easy(10);
            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission on hold - Suppression of civil rebellion", output.Trim());
        }

        [Test]
        public void TestMediumMissionOnHold()
        {
            IMission mission = new Medium(10);
            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission on hold - Capturing dangerous criminals", output.Trim());
        }

        [Test]
        public void TestHardMissionOnHold()
        {
            IMission mission = new Hard(10);
            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission on hold - Disposal of terrorists", output.Trim());
        }

        [Test]
        public void TestEasyMissionCompleted()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Easy(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission completed - Suppression of civil rebellion", output.Trim());
        }

        [Test]
        public void TestMediumMissionCompleted()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Medium(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission completed - Capturing dangerous criminals", output.Trim());
        }

        [Test]
        public void TestHardMissionCompleted()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Hard(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual($"Mission completed - Disposal of terrorists", output.Trim());
        }

        [Test]
        public void TestDeclineOldestMissionInQueue()
        {
            IMission mission1 = new Easy(100);
            IMission mission2 = new Medium(100);
            IMission mission3 = new Hard(100);
            IMission mission4 = new Hard(100);

            this.ms.Missions.Enqueue(mission1);
            this.ms.Missions.Enqueue(mission2);
            this.ms.Missions.Enqueue(mission3);

            string expected = "Mission declined - Suppression of civil rebellion\r\nMission on hold - Capturing dangerous criminals\r\nMission on hold - Disposal of terrorists\r\nMission on hold - Disposal of terrorists";
            string output = this.ms.PerformMission(mission4);

            Assert.AreEqual(expected, output.Trim());
        }

        // The tests below are correct but not needed for the Tests in Judge

        [Test]
        public void TestEasyMissionCompletedCount()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Easy(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual(1, this.ms.SuccessMissionCounter);
        }

        [Test]
        public void TestMediumMissionCompletedCount()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Medium(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual(1, this.ms.SuccessMissionCounter);
        }

        [Test]
        public void TestHardMissionCompletedCount()
        {
            Ranker ranker = new Ranker("A", 10, 100, 1000);
            ranker.Weapons["Gun"] = new Gun("Gun");
            ranker.Weapons["AutomaticMachine"] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons["Helmet"] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.ms = new MissionController(army, new WareHouse());
            IMission mission = new Hard(10);

            string output = this.ms.PerformMission(mission);

            Assert.AreEqual(1, this.ms.SuccessMissionCounter);
        }

        [Test]
        public void TestMissionQueueZeroCount()
        {
            Assert.AreEqual(0, this.ms.Missions.Count);
        }

        [Test]
        public void TestMissionQueueCount()
        {
            IMission mission1 = new Easy(100);
            IMission mission2 = new Medium(100);
            IMission mission3 = new Hard(100);

            this.ms.Missions.Enqueue(mission1);
            this.ms.Missions.Enqueue(mission2);
            this.ms.Missions.Enqueue(mission3);

            Assert.AreEqual(3, this.ms.Missions.Count);
        }

        [Test]
        public void TestFailedMissionCounter()
        {
            IMission mission1 = new Easy(100);
            IMission mission2 = new Medium(100);
            IMission mission3 = new Hard(100);

            this.ms.Missions.Enqueue(mission1);
            this.ms.Missions.Enqueue(mission2);
            this.ms.Missions.Enqueue(mission3);

            this.ms.FailMissionsOnHold();

            Assert.AreEqual(3, this.ms.FailedMissionCounter);
        }
    }
}