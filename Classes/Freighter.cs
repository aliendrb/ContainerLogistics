namespace ContainerLogistics.Classes
{
    public class Freighter : Vehicle
    {
        public List<Container> containers = new List<Container>();
        public Freighter(double maxSpeed, int maxContainers, double maxWeight) : base(maxSpeed, maxContainers, maxWeight) 
        {

        }
        public void Load(Container container) 
        {
            if(containers.Count()<MaxContainers && ((CurrentLoad+container.CargoMass+container.Weight) < MaxWeight*1000)) 
            {
                containers.Add(container);
                CurrentLoad += container.CargoMass + container.Weight;
            }
            else 
            {
                Console.WriteLine("Cannot load more containers");
            }
        }
        public void Load(List<Container> loadedContainers) 
        {
            double totalWeight = 0;
            foreach(Container container in loadedContainers) 
            {
                totalWeight += container.CargoMass + container.Weight;
            }
            if(((containers.Count()+loadedContainers.Count()) < MaxContainers) && ((CurrentLoad+totalWeight)<MaxWeight*1000)) 
            {
                foreach(Container container in loadedContainers) 
                {
                    containers.Add(container);
                }
                CurrentLoad += totalWeight;
            }
            else 
            {
                Console.WriteLine("Cannot load more containers");
            }
        }
        public void Unload(Container container) 
        {
            CurrentLoad -= (container.CargoMass+container.Weight);
            containers.Remove(container);
        }
        public void Swap(Container added, Container subtracted) 
        {
            CurrentLoad += (added.CargoMass+added.Weight) - (subtracted.CargoMass+subtracted.Weight);
            containers.Remove(subtracted);
            containers.Add(added);
        }
        public void SwitchShip(Container container, Freighter freighter) 
        {
            freighter.Load(container);
            Unload(container);
        }
        public void Info() 
        {
            Console.WriteLine($"Freighter {Id}\nMax speed: {MaxSpeed}\nMax weight: {MaxWeight}t\nMax containers: {MaxContainers}\nCurrent load: {CurrentLoad/1000}t\n");
            foreach(Container container in containers) 
            {
                Console.WriteLine(container.ToString());
            }
        }
    }
}
/*
 * Methods:
 * Loading container on board
 * Loading multiple containers on board
 * Unloading container from ship
 * Swapping one container from ship with another
 * Ability to move container between ships
 * Printing info about ship and its cargo
 */