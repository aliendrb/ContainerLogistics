using ContainerLogistics.Exception;
using ContainerLogistics.Interfaces;
using System.ComponentModel;

namespace ContainerLogistics.Classes
{
    public class LType(int height, double weight, int depth, double maxWeight) : Container(height, weight, depth, maxWeight), IHazardNotifier
    {
        public bool IsHazardOccured {  get; set; }
        public override string GenerateSerialNumber()
        {
            return "KON-L-" + Id;
        }

        public override void Load(Product product)
        {
            try
            {
                if (product.IsHazardous&&(product.Weight+CargoMass)>0.5*MaxWeight) 
                {
                    throw new OverfillException($"An overfill occured. Cargo is too heavy by {product.Weight + CargoMass - MaxWeight} kg");
                }
                else if (!product.IsHazardous&&(product.Weight+CargoMass)>0.9*MaxWeight)
                {
                    throw new OverfillException($"An overfill occured. Cargo is too heavy by {product.Weight + CargoMass - MaxWeight} kg");
                }
                else
                {
                    products.Add(product);
                    CargoMass += product.Weight;
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