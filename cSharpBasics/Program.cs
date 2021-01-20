using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cSharpBasics
{
    class Program
    {
        private static List<Bus> bussesList;
        private static List<Car> carsList;

        static void Main(string[] args)
        {
            StartBuildingFleet();
            AskUser();
        }

        static void StartBuildingFleet()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Starting build process ..");

            Console.Write("How many busses you want to add:");
            string read = Console.ReadLine();
            int numBusses;

            if (!int.TryParse(read, out numBusses))
            {
                Console.WriteLine("Please input valid number");
                StartBuildingFleet();
                return;
            }
            else if (numBusses <= 0)
            {
                Console.WriteLine("Please input positive value");
                StartBuildingFleet();
                return;
            }

            Console.Write("How many cars you want to add:");
            read = Console.ReadLine();
            int numCars;

            if (!int.TryParse(read, out numCars))
            {
                Console.WriteLine("Please input valid number");
                StartBuildingFleet();
                return;
            }
            else if (numCars <= 0)
            {
                Console.WriteLine("Please input positive value");
                StartBuildingFleet();
                return;
            }

            var response = CreateFleet(numBusses, numCars);
            if (response)
            {
                Console.WriteLine($"Created ..");
            }
        }

        static bool CreateFleet(int _busnum, int _carnum)
        {
            Console.WriteLine($"Creating a fleet of {_busnum} Buses and {_carnum} Cars");
            bussesList = new List<Bus>();
            carsList = new List<Car>();


            for (var i = 0; i < _busnum; i++)
            {
                string name = "Bus_" + i;

                Random random = new Random();
                int capacity = random.Next(15, 50);

                var buss = new Bus(name, capacity);
                bussesList.Add(buss);
            }

            for (var i = 0; i < _carnum; i++)
            {
                string c_name = "Car_" + i;
                carsList.Add(new Car { name = c_name, capacity = 4 });
            }


            Console.WriteLine($"Created a fleet of {bussesList.Count} Buses");
            return true;
        }

        static void AskUser()
        {
            Console.WriteLine("");
            Console.WriteLine("Hellow customer");
            Console.Write("How many passengers you want to transport:");
            string num = Console.ReadLine();
            if (num == "?")
            {
                PrintAll();
                AskUser();
                return;
            }
            if (!int.TryParse(num, out int _numPassengers))
            {
                Console.WriteLine("Please enter numeric value");
                AskUser();
                return;
            }

            if (_numPassengers <= 0)
            {
                Console.WriteLine("Please enter value more than 0");
                AskUser();
                return;
            }

            if (_numPassengers < 5)
            {
                Car _selectedCar = null;
                foreach (var car in carsList)
                {
                    if (car.currentCap + _numPassengers < car.capacity)
                    {
                        car.currentCap += _numPassengers;
                        _selectedCar = car;
                        break;
                    }
                }

                if (_selectedCar != null)
                {
                    Console.WriteLine($"We selected the car named {_selectedCar.name} total seats left in the car: {_selectedCar.capacity - _selectedCar.currentCap}");
                    AskUser();
                }
                else
                {
                    Console.WriteLine($"All cars are full");
                    AskUser();
                }
            }
            else
            {
                Bus _selecteBus = null;
                foreach (var bus in bussesList)
                {
                    if (bus.currentCap + _numPassengers < bus.capacity)
                    {
                        bus.currentCap += _numPassengers;
                        _selecteBus = bus;
                        break;
                    }
                }

                if (_selecteBus != null)
                {
                    Console.WriteLine($"We selected the Bus named {_selecteBus.name} total seats left in the bus: {_selecteBus.capacity - _selecteBus.currentCap}");
                    AskUser();
                }
                else
                {
                    Console.WriteLine($"All busses are full");
                    AskUser();
                }

            }

        }

        static void PrintAll()
        {
            Console.WriteLine($" ==== Buses[{bussesList.Count}] ==== ");

            foreach (var bus in bussesList)
            {
                bus.PrintMyData();
            }
            Console.WriteLine($" ==== Cars[{carsList.Count}] ==== ");

            foreach (var car in carsList)
            {
                car.PrintMyData();
            }
        }

    }

}
