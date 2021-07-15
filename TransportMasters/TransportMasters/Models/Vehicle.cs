using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TransportMasters.Models
{
    public class Vehicle : INotifyPropertyChanged
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
        public DateTime OfferStartTime { get; set; }
        public DateTime OfferEndtTime { get; set; }
        public TimeSpan _timespan { get; set; }
        public TimeSpan Timespan
        {
            get { return _timespan; }
            set
            {
                if (_timespan == value) return;
                
                _timespan = value;
                Days = _timespan.Days.ToString("00");
                Hours = _timespan.Hours.ToString("00");
                Minutes = _timespan.Minutes.ToString("00");
                Seconds = _timespan.Seconds.ToString("00");
                NotifyPropertyChanged();
            }
        }
        public string _timespanString { get; set; }
        public string TimespanString
        {
            get { return _timespanString; }
            set
            {
                if (_timespanString == value) return;
                _timespanString = value;
                NotifyPropertyChanged();
            }
        }

        public string _days;
        public string Days
        {
            get { return _days; }
            set
            {
                if (_days == value) return;
                _days = value;
                NotifyPropertyChanged();
            }
        }
        public string _hours;
        public string Hours
        {
            get { return _hours; }
            set
            {
                if (_hours == value) return;
                _hours = value;
                NotifyPropertyChanged();
            }
        }
        public string _minutes;
        public string Minutes
        {
            get { return _minutes; }
            set
            {
                if (_minutes == value) return;
                _minutes = value;
                NotifyPropertyChanged();
            }
        }
        public string _seconds;
        public string Seconds
        {
            get { return _seconds; }
            set
            {
                if (_seconds == value) return;
                _seconds = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
