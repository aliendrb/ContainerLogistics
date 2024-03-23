namespace ContainerLogistics.Classes
{
    public class GType : Container
    {
        public double Temperature { get; set; } = 273.15; //Temp in kelvin
        public double Pressure {  get; set; }
        public double Volume { get; }
        public double R { get; set; } = 8.314; //ideal gas constant J/(mol * K)
        public double MaxPressure { get; set; } = 443.61; //max pressure the tank can withstand, 443.61 atm
        public double MolarMass { get; set; } = 28.97; //molar mass of air 28.97g/mol
        public GType(int height, double weight, int depth, int width, double capacity) : base(height, weight, depth, width, capacity) 
        {
            Volume = (height / 100.0) * (depth / 100.0) * (width / 100.0);
            Capacity = calculateCapacity();
            Console.WriteLine($"TOTAL CAPACITY IN KG: {Capacity}");
        }
        public override string GenerateSerialNumber()
        {
            return "KON-G-" + Id;
        }

        public override void Load(Product product)
        {
            base.Load(product);
        }

        public double calculatePressure() 
        {
            double P = ((((CargoMass * 1000) / MolarMass) * R * Temperature) / Volume) / 1000.0; //this isn't accurate, it should be divided by 100_000 instead of 1000 at the end

            Console.WriteLine("Pressure inside the tank: " + P.ToString("0.00000") + " bar");
            return P;
        }

        public double calculateCapacity() 
        {
            return (((MaxPressure * Volume) / (R * Temperature)) * MolarMass); //capacity in kgs
        }

        public override void Unload(Product product)
        {
            CargoMass -= product.Mass * 0.95;
        }
        public void Prepare()
        {
            CargoMass = 0;
            products.Clear();
        }
        public void NotifyHazard(string type, Container container)
        {
            switch (type)
            {
                case "explosion":
                    Console.WriteLine($"Explosion at container {container.SerialNumber}");
                    break;
                case "leak":
                    Console.WriteLine($"Leak at container {container.SerialNumber}");
                    break;
                case "overheat":
                    Console.WriteLine($"Container {container.SerialNumber} is overheating.");
                    break;
                    //TODO: change this to push notifs and include different occurences
            }
        }
    }
}
/*
 * ADDITIONAL INFO
 * Gas container:
 *  - G type in serial number
 *  - Holds additional info about atmospheric pressure inside the container
 *  - While unloading this container 5% of its cargo is left inside
 *  - Implements interface IHazardNotifier which allows sending text notification in case of dangerous situation and includes container serial number
 *  - if cargo mass is greater than container capacity we should throw an exception
 */

//TODO: change up max weight etc, also do this in liquid container