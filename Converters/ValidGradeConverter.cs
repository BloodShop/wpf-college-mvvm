using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfDesignerAss.Converters
{
    internal class ValidGradeConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            double.TryParse(value.ToString(), out double grade) && grade >= 0 && grade <= 100 ? grade : -1;

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            double.TryParse(value.ToString(), out double grade) && grade >= 0 && grade <= 100 ? grade : -1;
    }
}
