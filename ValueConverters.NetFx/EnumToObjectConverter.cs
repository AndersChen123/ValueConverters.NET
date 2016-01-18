﻿using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
using System.Windows;
using System.Windows.Markup;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
#endif

namespace ValueConverters
{
    /// <summary>
    /// Source: http://stackoverflow.com/questions/2787725/how-to-display-different-enum-icons-using-xaml-only
    /// </summary>
#if (NETFX || WINDOWS_PHONE)
    [ContentProperty("Items")]
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
    [ContentProperty(Name = "Items")]
#endif
    public class EnumToObjectConverter : ConverterBase
    {
        public ResourceDictionary Items { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            string key = Enum.GetName(value.GetType(), value);
            if (this.Items != null && ContainsKey(this.Items, key))
            {
                return this.Items[key];
            }

            return DependencyProperty.UnsetValue;
        }

#if (NETFX || WINDOWS_PHONE)
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.Contains(key);
        }
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
        private static bool ContainsKey(ResourceDictionary dict, string key)
        {
            return dict.ContainsKey(key);
        }
#endif
    }
}
