using ContainerLogistics.Exception;
using ContainerLogistics.Interfaces;

namespace ContainerLogistics.Classes
{
    public abstract class Container : ISerialNumberGenerator
    {
        private static int _nextId = 1;
        public int Id { get; } = _nextId++;
        public double CargoMass { get; set; }
        public int Height { get; }
        public double Weight { get; }
        public int Width { get; }
        public int Depth { get; }
        public string SerialNumber { get; }
        public double Capacity { get; }
        public List<Product> products { get; set; } = new List<Product>();
        public string contentsList { get; set; }
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

        public void Unload(Product product) 
        {
            CargoMass -= product.Mass;
            products.Remove(product);
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
                    products.Add(product);
                    CargoMass += product.Mass;
                }
            }
            catch (OverfillException oe) 
            {
                Console.WriteLine(oe.Message);
            }
        }

        //could be generic type?
        public virtual string ListContents() 
        {
            foreach (Product product in products)
            {
                contentsList += $"[ID: {product.Id}, {product.Name}, {product.Mass} kg]\n";
            }
            return contentsList;
        }

        public override string ToString()
        {
            return $"\n\nSerial Number: {SerialNumber}\nWeight: {Weight} kg\nHeight: {Height} cm\nDepth: {Depth} cm\nMaximum Weight: {Capacity} kg\nCargo Weight: {CargoMass} kg\nContents:\n{ListContents()}\n\n";
        }
    }
}