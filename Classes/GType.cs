namespace ContainerLogistics.Classes
{
    public class GType(int height, double weight, int depth, double maxWeight) : Container(height, weight, depth, maxWeight)
    {
        public double AtmosphericPressure {  get; set; }
        public override string GenerateSerialNumber()
        {
            return "KON-G-" + Id;
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