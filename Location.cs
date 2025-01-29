namespace Game
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Interact(Player player)
        {
            Console.WriteLine(Description);
        }
    }
}