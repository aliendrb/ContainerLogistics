using ContainerLogistics.Classes;

namespace ContainerLogistics
{
    public class Program
    {
        static void Main(string[] args)
        {
            LType l1 = new LType(200, 50, 10000, 50000);
            Console.WriteLine(l1.SerialNumber);
            GType g1 = new GType(150, 30, 5000, 25000);
            Console.WriteLine(g1.SerialNumber);
            CType c1 = new CType(175, 45, 7500, 40000);
            Console.WriteLine(c1.SerialNumber);
            NType n1 = new NType(300, 75, 15000, 75000);
            Console.WriteLine(n1.SerialNumber);
        }
    }
}
