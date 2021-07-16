using System;
using System.Collections.Generic;
using System.Text;

namespace TransportMasters.Models
{
    public class Bid
    {
        public int id { get; set; }
        public int UserIdentyficator { get; set; }
        public int VehicleIdentyficator { get; set; }
        public long BidValue { get; set; }
        public DateTime Date { get; set; }

    }
}
