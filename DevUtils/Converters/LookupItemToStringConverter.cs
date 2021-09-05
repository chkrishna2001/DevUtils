using DevUtils.Core.Models;
using Microsoft.UI.Xaml.Data;
using System;

namespace DevUtils.Converters
{
    public class LookupItemToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
                return new LookupItem { ItemName = value.ToString(), ItemValue = value.ToString() };
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is LookupItem)
                return ((LookupItem)value).ItemValue;
            return value;
        }
    }
}
