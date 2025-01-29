namespace Game
{
    public class Monster : Creature
    {
        public Monster(string name, int health, int damage) : base(name, health, damage)
        { }

        public void Attack(Player player)
        {
            player.Health -= Damage;
            Console.WriteLine($"{Name} attacks! You lose {Damage} health.");
        }

        public void Defeat()
        {
            Console.WriteLine($"You have defeated the {Name}!");
        }
    }
}