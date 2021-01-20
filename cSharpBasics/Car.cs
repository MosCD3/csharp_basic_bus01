using System;
namespace cSharpBasics
{
    public class Car
    {
        public string name;
        public int capacity;
        public int currentCap;

        public Car()
        {
        }


        public void PrintMyData()
        {
            Console.WriteLine($"Car name: {name}, capacity: {capacity}, current load:{currentCap}");
        }
    
    }
}
