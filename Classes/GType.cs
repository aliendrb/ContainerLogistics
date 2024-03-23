namespace ContainerLogistics.Classes
{
    public class GType(int height, double weight, int depth, int width, double capacity) : Container(height, weight, depth, width, capacity)
    {
        public new double Capacity { get; set; } //= CalculateWeight();
        public double AtmosphericPressure {  get; set; }
        public override string GenerateSerialNumber()
        {
            return "KON-G-" + Id;
        }

        public void Load(Gas product)
        {
            base.Load(product); //slicing, change products<Product> to generic i think
        }

        public void Unload(Gas product)
        {

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
 * Gas container:
 *  - G type in serial number
 *  - Holds additional info about atmospheric pressure inside the container
 *  - While unloading this container 5% of its cargo is left inside
 *  - Implements interface IHazardNotifier which allows sending text notification in case of dangerous situation and includes container serial number
 *  - if cargo mass is greater than container capacity we should throw an exception
 */

//TODO: change up max weight etc, also do this in liquid container