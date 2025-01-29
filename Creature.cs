namespace Game
{
    public class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }
    }
}