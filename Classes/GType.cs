namespace ContainerLogistics.Classes
{
    public class GType(int height, double weight, int depth, int width, double capacity) : Container(height, weight, depth, width, capacity)
    {
        public new double Capacity { get; set; }
        public double AtmosphericPressure {  get; set; }
        public override string GenerateSerialNumber()
        {
            return "KON-G-" + Id;
        }

        public void Load(Product product)
        {
            base.Load(product);
        }

        //remove capacity from constructor, instead calculate it based on volume
        public void calculatePressure(Product product) 
        {
            AtmosphericPressure = product.Mass / Capacity;
        }

        public override void Unload(Product product)
        {
            CargoMass -= product.Mass * 0.95;
        }
        public void Prepare()
        {
            products.Clear();
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