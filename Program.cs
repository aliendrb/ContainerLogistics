using ContainerLogistics.Classes;

namespace ContainerLogistics
{
    public class Program
    {
        static void Main(string[] args)
        {
/*            LType l1 = new LType(200, 50, 10000, 50000);
            GType g1 = new GType(150, 30, 5000, 25000);
            CType c1 = new CType(175, 45, 7500, 40000);
            NType n1 = new NType(300, 75, 15000, 75000);
            LType l2 = new LType(100, 20, 3000, 5000);

            Product p1 = new Product("bananas", 100000);
            Product p2 = new Product("apples", 35000);
            Product p3 = new Product("oranges", 5000);*/

/*            Liquid pl1 = new Liquid("milk", 90000, false);
            LType l3 = new LType(10, 10, 10, 10, 100000);
            l3.Load(pl1);

            Liquid pl2 = new Liquid("apple juice", 100000, false);
            LType l4 = new LType(10, 10, 10, 10, 100000);
            l4.Load(pl2);

            Liquid pl3 = new Liquid("fuel", 50000, true);
            LType l5 = new LType(10, 10, 10, 10, 100000);
            l5.Load(pl3);

            Liquid pl4 = new Liquid("acid", 50001, true);
            LType l6 = new LType(10, 10, 10, 10, 100000);
            l6.Load(pl4);*/

/*            CType c1 = new CType(10, 10, 10, 10, 100, -10);
            Product r1 = new Product("frozen pizza", 10, false);
            Product r3 = new Product("bananas", 10, false);
            c1.Load(r1);
            c1.Load(r3);

            Product g1 = new Product("air", 0.1, false);
            GType c2 = new GType(200, 1, 200, 200, 1);
            Console.WriteLine(c2.calculatePressure());
            c2.Load(g1);
            Console.WriteLine(c2.ToString());
            c2.calculatePressure();*/
/*            CType c2 = new CType(10, 10, 10, 10, 100, 25);
            Refrigerated r2 = new Refrigerated("frozen pizza", 50);
            c2.Load(r2);*/

/*            Console.WriteLine(c1.ToString());

            Product l1 = new Product("water", 10, false);*/

/*            n1.Load(p1);
            n1.Load(p2);
            n1.Load(p3);
            Console.WriteLine(n1.ToString());*/

            //creating a freighter
            Freighter f1 = new Freighter(10, 1, 100);
            //over qty limit
            NType c1 = new NType(10, 1, 10, 10, 10);
            Product p1 = new Product("wood", 10, false);
            c1.Load(p1);
            Console.WriteLine(c1.ToString());
            NType c2 = new NType(10, 1, 10, 10, 10);
            c2.Load(p1);
            Console.WriteLine(c2.ToString());

            f1.Load(c1);
            f1.Unload(c1);
            f1.Load(c2);
            f1.Info();
            //over weight limit
            Freighter f2 = new Freighter(100, 100, 0.0001);
            f2.Load(c1);
            f2.Info();
        }
    }
}