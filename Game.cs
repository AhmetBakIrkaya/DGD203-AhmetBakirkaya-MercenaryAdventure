using System;

namespace Game
{
    public class Game
    {
        private Player player;
        private Menu menu;
        private bool isRunning;

        public Game()
        {
            menu = new Menu();
            player = new Player();
            isRunning = true;
        }

        public void Start()
        {
            while (isRunning)
            {
                Console.Clear();
                menu.ShowMainMenu();

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    NewGame();
                }
                else if (choice == "2")
                {
                    ShowCredits();
                }
            }
        }

        private void NewGame()
        {
            Console.Clear();
            player.Initialize();
            if (player.LoadGame())
            {
                Console.WriteLine("Game loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved game found. Starting a new game.");
            }

            while (true)
            {
                Console.Clear();
                player.DisplayStatus();
                player.Move();

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died. Would you like to load the last save or start a new game?");
                    Console.WriteLine("1. Load Last Save");
                    Console.WriteLine("2. New Game");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.LoadGame();
                    }
                    else if (choice == "2")
                    {
                        NewGame();
                    }
                }
            }
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("Game developed by Your Name.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
