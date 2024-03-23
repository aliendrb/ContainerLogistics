namespace ContainerLogistics.Classes
{
    public class Product
    {
        private static int _nextId = 1;
        public string Name { get; }
        public double Mass { get; }
        public int Id { get; } = _nextId++;
        public bool IsHazardous { get; }
        public Product(string name, double mass, bool isHazardous) 
        {
            Name = name;
            Mass = mass;
            IsHazardous = isHazardous;
        }
    }
}
