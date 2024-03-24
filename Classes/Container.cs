using ContainerLogistics.Exception;
using ContainerLogistics.Interfaces;

namespace ContainerLogistics.Classes
{
    public abstract class Container : ISerialNumberGenerator
    {
        private static int _nextId = 0;
        public int Id { get; } = _nextId++;
        public double CargoMass { get; set; }
        public int Height { get; }
        public double Weight { get; }
        public int Width { get; }
        public int Depth { get; }
        public string SerialNumber { get; }
        public double Capacity { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string ContentsList { get; set; }
        public bool IsHazardOccured {  get; set; }

        public Container(int height, double weight, int depth, int width, double capacity)
        {
            Height = height;
            Weight = weight;
            Width = width;
            Depth = depth;
            Capacity = capacity;
            SerialNumber = GenerateSerialNumber();
        }

        public abstract string GenerateSerialNumber();

        public virtual void Unload(Product product) 
        {
            CargoMass -= product.Mass;
            Products.Remove(product);
        }

        public virtual void Load(Product product) 
        {
            try 
            {
                if((product.Mass + CargoMass) > Capacity) 
                {
                    throw new OverfillException($"An overfill occured. Cargo is too heavy by {product.Mass + CargoMass - Capacity} kg");
                }
                else 
                {
                    Products.Add(product);
                    CargoMass += product.Mass;
                }
            }
            catch (OverfillException oe) 
            {
                Console.WriteLine(oe.Message);
            }
        }

        public virtual string ListContents() 
        {
            ContentsList = "";
            if (Products != null)
            {
                foreach (Product product in Products)
                {
                    ContentsList += $"[ID: {product.Id}, {product.Name}, {product.Mass} kg]\n";
                }
            }
            return ContentsList;
        }

        public override string ToString()
        {
            return $"Serial Number: {SerialNumber}\nWeight: {Weight} kg\nHeight: {Height} cm\nDepth: {Depth} cm\nMaximum Weight: {Capacity} kg\nCargo Weight: {CargoMass} kg\nContents:\n{ListContents()}";
        }
        public string GetSN() 
        {
            return SerialNumber;
        }
    }
}