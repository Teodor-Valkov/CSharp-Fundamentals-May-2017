namespace _04.Recharge.Models.Adapters
{
    public class RobotAdapter : IRechargeable
    {
        public RobotAdapter(string id, int capacity)
        {
            this.Robot = new Robot(id, capacity);
        }

        public Robot Robot { get; private set; }

        public void Recharge()
        {
            this.Robot.Recharge();
        }
    }
}