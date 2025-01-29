namespace Game
{
    public class Castle : Location
    {
        public Castle() : base("Castle", "This is the King's Castle where you can claim your rewards.")
        { }

        public override void Interact(Player player)
        {
            base.Interact(player);

            if (player.MonstersDefeated == 0)
            {
                Console.WriteLine("The king says: 'You haven't defeated any monsters yet. Come back when you've slain some.'");
            }
            else
            {
                Console.WriteLine("The king rewards you with gold!");
                player.Gold += 50;
                player.MonstersDefeated = 0;
            }

            Console.WriteLine("Press any key to leave...");
            Console.ReadKey();
        }
    }
}