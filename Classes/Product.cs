using System.Xml.Linq;

namespace ContainerLogistics.Classes
{
    public class Product
    {
        private static int _nextId = 1;
        public string Name { get; }
        public double Weight { get; }
        public bool IsHazardous { get; }
        public int Id { get; } = _nextId++;
        public Product(string name, double weight, bool isHazardous) 
        {
            Name = name;
            Weight = weight;
            IsHazardous = isHazardous;
        }
    }
}
