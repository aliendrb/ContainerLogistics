namespace ContainerLogistics.Classes
{
    public class LType(int height, float weight, int depth, float maxWeight) : Container(height, weight, depth, maxWeight)
    {
        public override string GenerateSerialNumber()
        {
            return "KON-L-" + Id;
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