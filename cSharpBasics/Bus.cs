using System;
namespace cSharpBasics
{
    public class Bus
    {
        public string name;
        public int capacity;
        public int currentCap;


        public Bus(string _name, int _cap)
        {
            name = _name;
            capacity = _cap;
        }



        public void PrintMyData()
        {
            Console.WriteLine($"Bus name: {name}, capacity: {capacity}, current load:{currentCap}");
        }
    }
}
