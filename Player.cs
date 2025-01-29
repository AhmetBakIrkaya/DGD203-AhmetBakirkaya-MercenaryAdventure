using System;
using System.Collections.Generic;

namespace Game
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Inventory Inventory { get; set; }
        public int MonstersDefeated { get; set; }
        public bool[] MonstersKilled { get; set; }

        public Player()
        {
            Health = 100;
            Gold = 50;
            Inventory = new Inventory();
            MonstersDefeated = 0;
            MonstersKilled = new bool[3];  // We have 3 monsters in the game
        }

        public void Initialize()
        {
            Console.Write("Enter your character's name: ");
            Name = Console.ReadLine();
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Monsters Defeated: {MonstersDefeated}");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            Console.WriteLine($"Health Potions: {Inventory.HealthPotions}");
            Console.WriteLine("Monster Heads:");
            foreach (var head in Inventory.MonsterHeads)
            {
                Console.WriteLine($"- {head}");
            }
        }

        public void Move()
        {
            Console.WriteLine("\nWhere would you like to go?");
            Console.WriteLine("1. Tavern");
            Console.WriteLine("2. Castle");
            Console.WriteLine("3. Monster lair 1");
            Console.WriteLine("4. Monster lair 2");
            Console.WriteLine("5. Monster lair 3");
            Console.WriteLine("6. Inventory");
            Console.WriteLine("7. Save Game");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Location chosenLocation;

            switch (choice)
            {
                case "1":
                    chosenLocation = new Tavern();
                    break;
                case "2":
                    chosenLocation = new Castle();
                    break;
                case "3":
                    chosenLocation = new MonsterLair(new Monster("Goblin", 30, 10), 0);
                    break;
                case "4":
                    chosenLocation = new MonsterLair(new Monster("Dragon", 80, 20), 1);
                    break;
                case "5":
                    chosenLocation = new MonsterLair(new Monster("Troll", 50, 15), 2);
                    break;
                case "6":
                    DisplayInventory();
                    return;
                case "7":
                    SaveGame();
                    return;
                default:
                    chosenLocation = null;
                    break;
            }

            if (chosenLocation != null)
            {
                chosenLocation.Interact(this);
            }

            // Check if all monsters are defeated
            if (MonstersDefeated == 3)
            {
                Console.WriteLine("Congratulations! You've defeated all monsters and completed the game!");
                Environment.Exit(0);  // Game ends successfully
            }
        }

        public void SaveGame()
        {
            string fileName = $"{Name}_save.txt";
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                writer.WriteLine(Name);
                writer.WriteLine(Health);
                writer.WriteLine(Gold);
                writer.WriteLine(MonstersDefeated);
                foreach (var killed in MonstersKilled)
                {
                    writer.WriteLine(killed);
                }
            }

            Console.WriteLine("Game saved successfully.");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public bool LoadGame()
        {
            string fileName = $"{Name}_save.txt";
            if (System.IO.File.Exists(fileName))
            {
                var reader = new System.IO.StreamReader(fileName);
                Name = reader.ReadLine();
                Health = int.Parse(reader.ReadLine());
                Gold = int.Parse(reader.ReadLine());
                MonstersDefeated = int.Parse(reader.ReadLine());
                for (int i = 0; i < MonstersKilled.Length; i++)
                {
                    MonstersKilled[i] = bool.Parse(reader.ReadLine());
                }
                reader.Close();

                return true;
            }
            else
            {
                Console.WriteLine("No save file found.");
                return false;
            }
        }
    }
}
