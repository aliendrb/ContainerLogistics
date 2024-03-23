namespace ContainerLogistics.Classes
{
    public class CType(int height, float weight, int depth, float maxWeight) : Container(height, weight, depth, maxWeight)
    {
        public override string GenerateSerialNumber()
        {
            return "KON-C-" + Id;
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