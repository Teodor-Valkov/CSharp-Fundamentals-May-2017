namespace _01.PawInc.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string centerName;
        private bool status;

        protected Animal(string name, int age, string centerName)
        {
            this.name = name;
            this.age = age;
            this.centerName = centerName;
            this.status = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string AdoptionCenterName
        {
            get
            {
                return this.centerName;
            }
        }

        public bool Status
        {
            get
            {
                return this.status;
            }
        }

        public void Cleanse()
        {
            this.status = true;
        }
    }
}