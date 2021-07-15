using System;
using System.Collections.Generic;
using System.Text;

namespace TransportMasters.Models
{
    class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Days => Timespan.Days.ToString("00");
        public string Hours => Timespan.Hours.ToString("00");
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
    }
}
