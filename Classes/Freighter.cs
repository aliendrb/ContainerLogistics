namespace ContainerLogistics.Classes
{
    public class Freighter : Vehicle
    {
        public List<Container> Containers = new List<Container>();
        public Freighter(double maxSpeed, int maxContainers, double maxWeight) : base(maxSpeed, maxContainers, maxWeight) 
        {
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
        }
        public void Load(Container container) 
        {
            foreach (Container checkedContainer in Containers)
            {
                if (checkedContainer.Id == container.Id) 
                {
                    Console.WriteLine($"Container with ID {container.Id} is already loaded.");
                    return;
                }
            }
            if (Containers.Count()<MaxContainers && ((CurrentLoad+container.CargoMass+container.Weight) < MaxWeight*1000)) 
            {
                Containers.Add(container);
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
            if(((Containers.Count()+loadedContainers.Count()) < MaxContainers) && ((CurrentLoad+totalWeight)<MaxWeight*1000)) 
            {
                foreach(Container container in loadedContainers) 
                {
                    foreach (Container checkedContainer in Containers)
                    {
                        if (checkedContainer.Id == container.Id)
                        {
                            Console.WriteLine($"Container with ID {container.Id} is already loaded.");
                        }
                        else 
                        {
                            Containers.Add(container);
                        }
                    }
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
            Containers.Remove(container);
        }
        public void Swap(Container added, Container subtracted) 
        {
            CurrentLoad += (added.CargoMass+added.Weight) - (subtracted.CargoMass+subtracted.Weight);
            Containers.Remove(subtracted);
            Containers.Add(added);
        }
        public void SwitchShip(Container container, Freighter freighter) 
        {
            freighter.Load(container);
            Unload(container);
        }
        public void Info() 
        {
            Console.WriteLine($"Freighter {Id}\nMax speed: {MaxSpeed}\nMax weight: {MaxWeight}t\nMax containers: {MaxContainers}\nCurrent load: {CurrentLoad/1000}t\n");
            if (Containers != null)
            {
                foreach (Container container in Containers)
                {
                    Console.WriteLine(container.ToString());
                }
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