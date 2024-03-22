using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLogistics.Classes
{
    public class Vehicle
    {
    }
}
// Requirements specify that there is only one type of vehicle needed: freighter
// Since the attributes are the same, they will be implemented in this class: current container load, max speed, max container quantity, max container weight (tonnes)
// Because freighter speed is given in knots (kt), it has to be converted to km/h to keep speed units consistent
// 1 knot = 1.852 km/h