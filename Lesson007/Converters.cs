using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace Lesson007
{
    class MatchesToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MatchCollection aMatches = value as MatchCollection;
            if (aMatches == null) return null;
            string aResult = "";
            foreach (Match aMatch in aMatches)
                aResult += aMatch.Value + "\n";
            return aResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
