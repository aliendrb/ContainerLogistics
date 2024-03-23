using ContainerLogistics.Exception;

namespace ContainerLogistics.Classes
{
    public class NType(int height, double weight, int depth, int width, double capacity) : Container(height, weight, depth, width, capacity)
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