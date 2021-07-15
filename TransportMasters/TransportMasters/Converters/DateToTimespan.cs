using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TransportMasters.Converters
{
    public class DateToTimespan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //int parsedDate=0;
            //TimeSpan Timespan;
            //if (value != null)
            //{
            //    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //    {
            //        var _value = value.ToString();
            //        //var parsedDate = DateTime.Parse(_value);

            //        //Timespan = parsedDate - DateTime.Now;
            //        parsedDate = int.Parse(_value);
            //        parsedDate++;
            //        return true;
            //    });
            //}
            
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
