using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE //
{
    public class Address
    {
        //fileds
        public string streetName;
        public int numberOfBuilding;
        public string city;
        //ctor
        public Address(string _streetName ="", int _numberOfBuilding =0, string _city ="")
        {
            streetName = _streetName;
            numberOfBuilding = _numberOfBuilding;
            city = _city;
        }
        //properties
        public string StreetName { get => streetName; set => streetName = value; }
        public int NumberOfBuilding { get => numberOfBuilding; set => numberOfBuilding = value; }
        public string City { get => city; set => city = value; }
    }
}
