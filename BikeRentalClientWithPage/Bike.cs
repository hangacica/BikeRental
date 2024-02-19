using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalClientWithPage
{
    internal class Bike
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public DateTime? Manufactured { get; set; }
        public override string ToString()
        {
            return $"{Brand} - {Name}";
        }
    }
}
