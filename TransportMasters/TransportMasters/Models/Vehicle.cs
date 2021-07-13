using System;
using System.Collections.Generic;
using System.Text;

namespace TransportMasters.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string CarManufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float StartPrice { get; set; }
        public int CarCondition { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Driver { get; set; }
        public int Cargo { get; set; }
        public bool OnMarket { get; set; }
    }
}
