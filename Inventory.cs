namespace Game
{
    public class Inventory
    {
        public int HealthPotions { get; set; }
        public List<string> MonsterHeads { get; set; }

        public Inventory()
        {
            HealthPotions = 0;
            MonsterHeads = new List<string>();
        }

        public void AddPotion()
        {
            HealthPotions++;
            Console.WriteLine("You have obtained a health potion!");
        }

        public void AddMonsterHead(string monsterName)
        {
            MonsterHeads.Add(monsterName + " Head");
            Console.WriteLine($"You have obtained the head of {monsterName}!");
        }
    }
}