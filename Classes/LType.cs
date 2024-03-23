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
                    throw new OverfillException($"An overfill occured in container {SerialNumber}. Cargo is too heavy by {product.Mass + CargoMass - Capacity*0.5} kg");
                }
                else if (!product.IsHazardous&&(product.Mass+CargoMass)>0.9*Capacity)
                {
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

        public void NotifyHazard(string message, Container container)
        {
            do
            {
                if (IsHazardOccured)
                {
                    Console.WriteLine($"Hazardous occurence: {message} at container {container.SerialNumber}");
                    //TODO: change this to push notifs and include different occurences
                }
            }
            while (!IsHazardOccured);
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