using ContainerLogistics.Exception;

namespace ContainerLogistics.Classes
{
    public class NType(int height, double weight, int depth, int width, double capacity) : Container(height, weight, depth, width, capacity)
    {
        public override string GenerateSerialNumber()
        {
            return "KON-N-" + Id;
        }
        public override void Load(Product product)
        {
            try
            {
                if ((product.Mass + CargoMass) > Capacity)
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
    }
}
/*
 * ADDITIONAL INFO
 * My structure implementation requires that I add also normal type containers (N type in serial number)
 *  - because it is my own class, not specified by the requirements, there are no rules besides the weight capacity
 */