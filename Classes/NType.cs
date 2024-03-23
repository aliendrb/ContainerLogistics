namespace ContainerLogistics.Classes
{
    public class NType(int height, float weight, int depth, float maxWeight) : Container(height, weight, depth, maxWeight)
    {
        public override string GenerateSerialNumber()
        {
            return "KON-N-" + Id;
        }
    }
}
/*
 * ADDITIONAL INFO
 * My structure implementation requires that I add also normal type containers (N type in serial number)
 *  - because it is my own class, not specified by the requirements, there are no rules besides the weight capacity
 */