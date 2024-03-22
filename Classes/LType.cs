﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
