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
                        Freighters.ElementAt(temp).Load(Containers.ElementAt(Int32.Parse(Console.ReadLine())));
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
                        Freighters.ElementAt(temp).Unload(Containers.ElementAt(Int32.Parse(Console.ReadLine())));
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
                Console.WriteLine(container.ToString()); //make Info(); method
            }
        }
    }
}
/*
 * 
 * 
  while (resume)
                {
                    Console.Clear();
                    Console.WriteLine("Possible actions:\n1. Add freigher\n2. Add container");
                    if (Freighters.Count == 0)
                    {
                        if (Containers.Count == 0)
                        {
                            //Console.WriteLine("0 fre, 0 cont");
                            Console.WriteLine("3. Exit");
                        }
                        else
                        {
                            //Console.WriteLine("0 fre, 0<cont");
                            Console.WriteLine("3. Select container\n4. Exit");
                        }
                        Console.Write("Input: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Containers value has to be an integer. Weight is measured in tonnes.\nFollow this format: maxSpeed,maxContainers,maxWeight");
                                input = Console.ReadLine();
                                string[] strings = input.Split(',');
                                new Freighter(Int32.Parse(strings.ElementAt(0)), Int32.Parse(strings.ElementAt(1)), Int32.Parse(strings.ElementAt(2)));
                                resume = false;
                                break;
                            case "2":
                                Console.WriteLine("Select type of container you'd like to register:\n1. Liquid container\n2. Gas container\n3.Refrigerated container");
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                }
                                resume = false;
                                break;
                            case "3":
                                resume = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect input");
                                Thread.Sleep(2000);
                                resume = true;
                                break;
                        }
                    }
                    else
                    {
                        if (Containers.Count == 0)
                        {
                            //Console.WriteLine("0<fre, 0 cont");
                            Console.WriteLine("3. Select freighter");
                        }
                        else
                        {
                            //Console.WriteLine("0<fre, 0<cont");
                            Console.WriteLine("3. Select freighter\n4. Select container");
                        }
                    }
                    if (Freighters.Count == 0)
                    {
                        Console.WriteLine("No freighters registered.");
                    }
                    else
                    {
                        foreach (Freighter freighter in Freighters)
                        {
                            Console.WriteLine($"Freighter: {freighter.Id}");
                        }
                    }
                    if (Containers.Count == 0)
                    {
                        Console.WriteLine("No containers registered.");
                    }
                    else
                    {
                        foreach (Container container in Containers)
                        {
                            Console.WriteLine(container.Id);
                        }
                    }
                    break;
                }
 
 
 
 
 */






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

/*            //creating a freighter
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
            f2.Info();*/