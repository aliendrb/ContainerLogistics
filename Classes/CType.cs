using ContainerLogistics.Exception;

namespace ContainerLogistics.Classes
{
    public class CType(int height, double weight, int depth, int width, double capacity, double temperatureInside) : Container(height, weight, depth, width, capacity)
    {
        public static Dictionary<string, double> maximumTemperatures = new Dictionary<string, double>()
        {
            {"bananas", 13.3 },
            {"chocolate", 18 },
            {"fish", 2 },
            {"meat", -15 },
            {"ice cream", -18 },
            {"frozen pizza", -30 },
            {"cheese", 7.2 },
            {"sausages", 5 },
            {"butter", 20.5 },
            {"eggs", 19 },
        };
        public double TemperatureInside { get; set; } = temperatureInside;
        public override string GenerateSerialNumber()
        {
            return "KON-C-" + Id;
        }
        public override void Load(Product product)
        {
            double minTemp;
            maximumTemperatures.TryGetValue(product.Name, out minTemp);
            if (minTemp < TemperatureInside)
            {
                Console.WriteLine("Cannot store this product here, the temperature is too high!");
                return;
            }
            if (Products.Count > 0)
            {
                foreach (Product product_1 in Products)
                {
                    if (product_1.Name != product.Name)
                    {
                        Console.WriteLine("You can only store one type of cargo in this container");
                        return;
                    }
                }
            }
            base.Load(product);
        }


        //CODE DOUBLING
        public override string ToString()
        {
            return $"Temperature inside: {TemperatureInside}\n"+base.ToString();
        }
    }
}
/*
 * ADDITIONAL INFO
 * Refrigerated container:
 *  - C type in serial number
 *  - Holds additional info: 
 *      - cargo type that can be stored in the specified container
 *      - temperature inside the container
 *  - The container can only hold one type of cargo
 *  - Temperature inside the container cannot be lower than minimum storing temperature required by specified cargo type
 * 
 * Product/Temperature chart:
 *  Bananas: 13,3
 *  Chocolate: 18
 *  Fish: 2
 *  Meat: -15
 *  Ice cream: -18
 *  Frozen pizza: -30
 *  Cheese: 7,2
 *  Sausages: 5
 *  Butter: 20,5
 *  Eggs: 19
 */