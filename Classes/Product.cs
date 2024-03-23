using System.Xml.Linq;

namespace ContainerLogistics.Classes
{
    public class Product
    {
        private static int _nextId = 1;
        public string Name { get; }
        public double Mass { get; }
        public int Id { get; } = _nextId++;
        public Product(string name, double mass) 
        {
            Name = name;
            Mass = mass;
        }
    }
}
