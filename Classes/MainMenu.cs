using System.Linq.Expressions;

namespace ContainerLogistics.Classes
{
    public class MainMenu
    {
        List<Freighter> Freighters = new List<Freighter>();
        List<Container> Containers = new List<Container>();
        string input = "";
        bool resume = true;
        bool Found = true;
        public MainMenu() 
        {
            Start();
        }
        public void Start() 
        {
            while (resume)
            {
                Console.Clear();
                ListFreighters();
                ListContainers();
                Startup();
            }
        }
        public void Startup() 
        {
            Console.WriteLine("Possible actions:\n1. Add freigher\n2. Add container");
            if (Freighters.Count == 0) 
            {
                if(Containers.Count == 0) 
                {
                    Console.WriteLine("3. Exit");
                    switch (Console.ReadLine()) 
                    {
                        case "1":
                            FreighterAdd();
                            break;
                        case "2":
                            ContainerAdd();
                            break;
                        case "3":
                            Console.Clear();
                            resume = false;
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("3. Select container\n4. Exit");
                    switch (Console.ReadLine() ) 
                    {
                        case "1":
                            FreighterAdd();
                            break;
                        case "2":
                            ContainerAdd();
                            break;
                        case "3":
                            ContainerOptions();
                            break;
                        case "4":
                            resume = false;
                            break;
                    }
                }
            }
            else 
            {
                if(Containers.Count == 0) 
                {
                    Console.WriteLine("3. Select freighter\n4. Exit");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            FreighterAdd();
                            break;
                        case "2":
                            ContainerAdd();
                            break;
                        case "3":
                            FreighterOptions();
                            break;
                        case "4":
                            resume = false;
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("3. Select freighter\n4. Select container\n5. Exit");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            FreighterAdd();
                            break;
                        case "2":
                            ContainerAdd();
                            break;
                        case "3":
                            FreighterOptions();
                            break;
                        case "4":
                            ContainerOptions();
                            break;
                        case "5":
                            resume = false;
                            break;
                    }
                }
            }
        }
        public void FreighterOptions() 
        {
            Console.Clear();
            ListFreighters();
            Console.Write("Freighter ID input: ");
            input = Console.ReadLine();
            Console.Clear();
            if (Int32.Parse(input) > Freighters.Count)
            {
                Console.WriteLine("Invalid ID.");
            }
            else
            {
                int temp = Int32.Parse(input);
                Freighters.ElementAt(Int32.Parse(input)).Info();
                Console.WriteLine("1. Load container\n2. Load multiple containers\n3. Unload container\n4. Delete freighter\n5. Swap container between freighters\n6. Switch container with a different one\n7. Return");
                Console.Write("Input: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListContainers();
                        Console.Write("Serial number input, only the number part: ");
                        Freighters.ElementAt(temp).Load(Containers.ElementAt(Int32.Parse(Console.ReadLine()))); //fix this id != [] index
                        break;
                    case "2":
                        ListContainers();
                        Console.Write("Formatting: number,number,number,number...\nSerial numbers input, only the number part: ");
                        input = Console.ReadLine();
                        string[] strings = input.Split(',');
                        List<Container> tempContainers = new List<Container>();
                        foreach(string s in strings) 
                        {
                            foreach(Container container in Containers) 
                            {
                                if(container.Id == Int32.Parse(s)) 
                                {
                                    tempContainers.Add(container);
                                }
                            }
                        }
                        Freighters.ElementAt(temp).Load(tempContainers);
                        break;
                    case "3":
                        ListContainers();
                        Console.Write("Serial number input, only the number part: ");
                        Freighters.ElementAt(temp).Unload(Containers.ElementAt(Int32.Parse(Console.ReadLine()))); //fix this id != index
                        break;
                    case "4":
                        Freighters.Remove(Freighters.ElementAt(temp));
                        break;
                    case "5":
                        ListContainers();
                        Console.Write("Formatting: containerID,freighterID\nSerial numbers input, only the number part: ");
                        input = Console.ReadLine();
                        string[] strings2 = input.Split(',');
                        Freighters.ElementAt(temp).SwitchShip(Containers.ElementAt(Int32.Parse(strings2.ElementAt(0))), Freighters.ElementAt(Int32.Parse(strings2.ElementAt(1))));
                        break;
                    case "6":
                        ListContainers();
                        Console.Write("Formatting: loadContainerID,unloadContainerID\nSerial numbers input, only the number part: ");
                        input = Console.ReadLine();
                        string[] strings3 = input.Split(',');
                        Freighters.ElementAt(temp).Swap(Containers.ElementAt(Int32.Parse(strings3.ElementAt(0))), Containers.ElementAt(Int32.Parse(strings3.ElementAt(1))));
                        break;
                    case "7":

                        break;
                }
            }
        }
        public void ContainerOptions() 
        {
            Console.Clear();
            ListContainers();
            Console.Write("Container ID input: ");
            input = Console.ReadLine();
            foreach (Container container in Containers) 
            {
                if (container.Id==Int32.Parse(input)) 
                {
                    Found = true;
                    break;
                }
                Found = false;
            }

            Console.Clear();
            if (!Found)
            {
                Console.WriteLine("Invalid ID.");
                Thread.Sleep(1500);
            }
            else
            {
                int temp = Int32.Parse(input);
                Console.WriteLine(Containers.ElementAt(Int32.Parse(input)).ToString());
                Console.WriteLine("1. Load container\n2. Unload container\n3. Delete container\n4. Return");
                Console.Write("Input: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("string,double,bool\nProduct formatting: name,mass,dangerous"); //make condition to only apply bool to liquids and gasses
                        Console.Write("Input: ");
                        input = Console.ReadLine();
                        string[] strings = input.Split(',');
                        Containers.ElementAt(temp).Load(new Product(strings.ElementAt(0), Double.Parse(strings.ElementAt(1)),Boolean.Parse(strings.ElementAt(2))));
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(Containers.ElementAt(temp).ToString());
                        Console.Write("ID of product to unload: ");
                        input = Console.ReadLine();
                        Containers.ElementAt(temp).Unload(Containers.ElementAt(temp).Products.ElementAt(Int32.Parse(input)-1));
                        break;
                    case "3":
                        Containers.Remove(Containers.ElementAt(temp));
                        break;
                    case "4":
                        break;
                }
            }
        }
        public void FreighterAdd()
        {
            Console.Clear();
            Console.WriteLine("Containers value has to be an integer. Weight is measured in tonnes.\nFollow this format: maxSpeed,maxContainers,maxWeight");
            input = Console.ReadLine();
            string[] strings = input.Split(',');
            Freighters.Add(new Freighter(Double.Parse(strings.ElementAt(0)), Int32.Parse(strings.ElementAt(1)), Double.Parse(strings.ElementAt(2))));
        }
        public void ContainerAdd()
        {
            Console.Clear();
            input = "";
            Console.WriteLine("Height/depth/width values have to be an integers, measured in centimeters.\nWeight/capacity are measured in kilograms.\nTypes: liquid,gas,cooled,normal\nFollow this format: type,height,weight,depth,width,capacity");
            input = Console.ReadLine();
            string[] strings = input.Split(',');
            switch (strings.ElementAt(0)) 
            {
                case "liquid":
                    Containers.Add(new LType(Int32.Parse(strings.ElementAt(1)), Double.Parse(strings.ElementAt(2)), Int32.Parse(strings.ElementAt(3)), Int32.Parse(strings.ElementAt(4)), Double.Parse(strings.ElementAt(5))));
                    break;
                case "gas":
                    Containers.Add(new GType(Int32.Parse(strings.ElementAt(1)), Double.Parse(strings.ElementAt(2)), Int32.Parse(strings.ElementAt(3)), Int32.Parse(strings.ElementAt(4)), Double.Parse(strings.ElementAt(5))));
                    break;
                case "cooled":
                    Console.Write("Input temperature inside: ");
                    input = Console.ReadLine();
                    Containers.Add(new CType(Int32.Parse(strings.ElementAt(1)), Double.Parse(strings.ElementAt(2)), Int32.Parse(strings.ElementAt(3)), Int32.Parse(strings.ElementAt(4)), Double.Parse(strings.ElementAt(5)), Double.Parse(input)));
                    break;
                case "normal":
                    Containers.Add(new NType(Int32.Parse(strings.ElementAt(1)), Double.Parse(strings.ElementAt(2)), Int32.Parse(strings.ElementAt(3)), Int32.Parse(strings.ElementAt(4)), Double.Parse(strings.ElementAt(5))));
                    break;
            }
        }
        public void ListFreighters() 
        {
            if (Freighters.Count == 0)
            {
                Console.WriteLine("No freighters registered.");
                return;
            }
            foreach (Freighter freighter in Freighters) 
            {
                freighter.Info();
            }
        }
        public void ListContainers() 
        {
            if (Containers.Count == 0)
            {
                Console.WriteLine("No containers registered.");
                return;
            }
            foreach (Container container in Containers) 
            {
                container.Info();
            }
        }
    }
}