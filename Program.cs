﻿using ContainerLogistics.Classes;

namespace ContainerLogistics
{
    public class Program
    {
        static void Main(string[] args)
        {
            LType l1 = new LType(200, 50, 10000, 50000);
            GType g1 = new GType(150, 30, 5000, 25000);
            CType c1 = new CType(175, 45, 7500, 40000);
            NType n1 = new NType(300, 75, 15000, 75000);
            LType l2 = new LType(100, 20, 3000, 5000);
            Product p1 = new Product("bananas", 100000, false);
            Product p2 = new Product("apples", 35000, false);
            Product p3 = new Product("oranges", 5000, false);
            n1.Load(p1);
            n1.Load(p2);
            n1.Load(p3);
            Console.WriteLine(n1.ToString());
        }
    }
}