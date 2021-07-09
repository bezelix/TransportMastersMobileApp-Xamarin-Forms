using System;
using System.Collections.Generic;
using System.Text;

namespace TransportMasters.Models
{
    class Vehicle
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int CarManufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float StartPrice { get; set; }
        public int CarCondition { get; set; }
        public string LocalizationN { get; set; }
        public string LocalizationE { get; set; }
        public int Driver { get; set; }
        public int Cargo { get; set; }
    }
}
