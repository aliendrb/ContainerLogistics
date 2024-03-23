using ContainerLogistics.Classes;
using System;

namespace ContainerLogistics.Classes
{
    public class Refrigerated : Product
    {
        public Refrigerated(string name, double mass) : base(name, mass)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}