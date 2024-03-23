namespace ContainerLogistics.Classes
{
    public class Vehicle
    {
        public static int _nextId = 0;
        public int Id { get; set; } = _nextId++;
        public double CurrentLoad {get; set;}
        public double MaxSpeed { get; set;}
        public int MaxContainers {  get; set;}
        public double MaxWeight {  get; set;}
        public Vehicle(double maxSpeed, int maxContainers, double maxWeight) 
        {
            CurrentLoad = 0;
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
        }
    }
}
// Requirements specify that there is only one type of vehicle needed: freighter
// Since the attributes are the same, they will be implemented in this class: current container load, max speed, max container quantity, max container weight (tonnes)
// Because freighter speed is given in knots (kt), it has to be converted to km/h to keep speed units consistent
// 1 knot = 1.852 km/h