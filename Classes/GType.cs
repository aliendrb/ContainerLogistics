using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLogistics.Classes
{
    public class GType(int height, float weight, int depth, float maxWeight) : Container(height, weight, depth, maxWeight)
    {
        public override string GenerateSerialNumber()
        {
            return "KON-G-" + Id;
        }
    }
}
