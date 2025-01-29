namespace Game
{
    public class MonsterLair : Location
    {
        private Monster monster;
        private int index;

        public MonsterLair(Monster monster, int index) : base(monster.Name + " Lair", "You have entered the lair of " + monster.Name)
        {
            this.monster = monster;
            this.index = index;
        }

        public override void Interact(Player player)
        {
            if (player.MonstersKilled[index])
            {
                Console.WriteLine($"You have already defeated the {monster.Name}. There's nothing here.");
                return;
            }

            base.Interact(player);
            Console.WriteLine($"A wild {monster.Name} appears!");

            Console.WriteLine("Do you wish to fight? (y/n)");

            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Fight(player);
            }
        }

        private void Fight(Player player)
        {
            Random random = new Random();
            while (monster.Health > 0 && player.Health > 0)
            {
                int damage = random.Next(5, 15);
                monster.TakeDamage(damage);
                Console.WriteLine($"You dealt {damage} damage to {monster.Name}.");

                if (monster.Health <= 0)
                {
                    player.MonstersKilled[index] = true;
                    player.MonstersDefeated++;
                    player.Inventory.AddMonsterHead(monster.Name); // Add monster head to inventory
                    break;
                }

                damage = random.Next(5, 15);
                player.Health -= damage;
                Console.WriteLine($"{monster.Name} dealt {damage} damage to you.");

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated by the monster!");
                    break;
                }
            }
        }
    }
}