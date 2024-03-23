using System.Xml.Linq;

namespace ContainerLogistics.Classes
{
    public class Product
    {
        private static int _nextId = 1;
        public string Name { get; }
        public float Weight { get; }
        public int Id { get; } = _nextId++;
        public Product(string name, float weight) 
        {
            Name = name;
            Weight = weight;
        }
    }
}
