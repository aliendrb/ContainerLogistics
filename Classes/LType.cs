using ContainerLogistics.Exception;
using ContainerLogistics.Interfaces;

namespace ContainerLogistics.Classes
{
    public class LType(int height, double weight, int depth, int width, double capacity) : Container(height, weight, depth, width, capacity), IHazardNotifier
    {
        public override string GenerateSerialNumber()
        {
            return "KON-L-" + Id;
        }

        public override void Load(Product product)
        {
            try
            {
                if (product.IsHazardous && (product.Mass + CargoMass) > 0.5 * Capacity)
                {
                    NotifyHazard("overfill", this);
                    throw new OverfillException($"An overfill occured in container {SerialNumber}. Cargo is too heavy by {product.Mass + CargoMass - Capacity*0.5} kg");
                }
                else if (!product.IsHazardous&&(product.Mass+CargoMass)>0.9*Capacity)
                {
                    NotifyHazard("overfill", this);
                    throw new OverfillException($"An overfill occured in container {SerialNumber}. Cargo is too heavy by {product.Mass + CargoMass - Capacity*0.9} kg");
                }
                else
                {
                    //I could do base.Load() here but it has additional ifs that would have to be checked.
                    products.Add(product);
                    CargoMass += product.Mass;
                }
            }
            catch (OverfillException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }

        public void NotifyHazard(string type, Container container)
        {
            switch (type)
            {
                case "explosion":
                    Console.WriteLine($"Explosion at container {container.SerialNumber}");
                    break;
                case "leak":
                    Console.WriteLine($"Leak at container {container.SerialNumber}");
                    break;
                case "overheat":
                    Console.WriteLine($"Container {container.SerialNumber} is overheating.");
                    break;
                case "overfill":
                    Console.WriteLine($"Container {container.SerialNumber} has been overfilled, check it immediately.");
                    break;
                    //TODO: change this to push notifs and include different occurences
            }
        }
    }

}
/*
 * ADDITIONAL INFO
 * Liquid container:
 *  - L type in serial number (e.g. KON-L-1)
 *  - Allow liquid transportation
 *      - two types of liquids: hazardous (e.g. fuel), normal (e.g. milk)
 *  - Implements interface IHazardNotifier which allows sending text notification in case of dangerous situation and includes container serial number
 *  - When running loading method we should check:
 *      - if the container's holding hazardous cargo, we can only fill 50% of total capacity
 *      - otherwise we can fill 90% of total capacity
 *      - push notification about dangerous user action if user tries to fill more than permitted by these rules
 */