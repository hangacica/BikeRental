using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalClient
{
    public class Bike
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public DateTime? Manufactured { get; set; }
        public string? Type { get; set; }

        internal static Bike FromCsv(string line)
        {
            string[] splits = line.Split('|');
            Bike bike = new Bike();
            bike.Name = splits[0];
            bike.Brand = splits[1];
            bike.Type = splits[2];
            bike.Manufactured = DateTime.Parse(splits[3]);
            return bike;
        }

        public string ToCsv()
        {
            return $"{Name}|{Brand}|{Type}|{Manufactured}";
        }
        public override string ToString()
        {
            return $"{Brand} - {Name}";
        }




    }
}
