namespace _02.Blob.Contracts
{
    public interface IBlobRepository
    {
        void CreateBlob(string name, int health, int damage, IBehaviour behaviour, IAttack attack);

        void Pass();

        void GetStatus();

        void Attack(string attacker, string target);
    }
}