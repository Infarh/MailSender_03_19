using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MailSender.WPF.Converters
{
    class DebugBindingConverter : IValueConverter
    {
        private bool _Break = true;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (App.IsInDebugModel && _Break)
                System.Diagnostics.Debugger.Break();

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (App.IsInDebugModel && _Break)
                System.Diagnostics.Debugger.Break();

            return value;
        }
    }
}
