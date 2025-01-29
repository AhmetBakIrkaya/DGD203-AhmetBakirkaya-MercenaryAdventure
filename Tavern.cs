namespace Game
{
    public class Tavern : Location
    {
        public Tavern() : base("Tavern", "This is a local tavern where you can buy health potions.")
        { }

        public override void Interact(Player player)
        {
            base.Interact(player);
            Console.WriteLine("Would you like to buy a health potion for 10 gold? (y/n)");

            if (player.Gold < 10)
            {
                Console.WriteLine("You don't have enough gold to buy a health potion.");
                Console.WriteLine("Press any key to leave...");
                Console.ReadKey();
            }
            else
            {
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    player.Gold -= 10;
                    player.Inventory.AddPotion();
                }
            }
        }
    }
}