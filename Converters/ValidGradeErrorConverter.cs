using System;
using System.Globalization;
using System.Windows;

namespace WpfDesignerAss.Converters
{
    internal class ValidGradeErrorConverter : ValidGradeConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            double.Parse(base.Convert(value, targetType, parameter, culture).ToString()) == -1 ? Visibility.Visible : Visibility.Collapsed;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            double.Parse(base.ConvertBack(value, targetType, parameter, culture).ToString()) == -1 ? Visibility.Visible : Visibility.Collapsed;
    }
}