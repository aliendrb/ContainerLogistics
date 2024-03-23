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

            Liquid pl1 = new Liquid("milk", 90000, false);
            LType l3 = new LType(10, 10, 10, 100000);
            l3.Load(pl1);

            Liquid pl2 = new Liquid("apple juice", 100000, false);
            LType l4 = new LType(10, 10, 10, 100000);
            l4.Load(pl2);

            Liquid pl3 = new Liquid("fuel", 50000, true);
            LType l5 = new LType(10, 10, 10, 100000);
            l5.Load(pl3);

            Liquid pl4 = new Liquid("acid", 50001, true);
            LType l6 = new LType(10, 10, 10, 100000);
            l6.Load(pl4);

/*            n1.Load(p1);
            n1.Load(p2);
            n1.Load(p3);
            Console.WriteLine(n1.ToString());*/
        }
    }
}