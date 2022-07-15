using System;
using System.Globalization;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters {
    /// <summary>
    /// Multiplies to numerical values.
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    public class ValueMultiplier : IValueConverter {
        /// <summary>
        /// Executes a multiplication.
        /// </summary>
        /// <param name="value">Multiplier</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Multiplicand</param>
        /// <param name="culture">UNUSED</param>
        /// <returns>The product.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value is double multiplier || double.TryParse(value.ToString(), out multiplier))
                && (parameter is double multiplicand || double.TryParse(parameter.ToString(), out multiplicand))
                ? multiplier * multiplicand
                : value;
        }

        /// <summary>
        /// Executes a division.
        /// </summary>
        /// <param name="value">Dividend</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Divisor</param>
        /// <param name="culture">UNUSED</param>
        /// <returns>The quotient or <see cref="double.NaN"/> if divisor is zero.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value is double dividend || double.TryParse(value.ToString(), out dividend))
                && (parameter is double divisor || double.TryParse(parameter.ToString(), out divisor))
                ? divisor == 0.0 ? double.NaN : dividend / divisor
                : value;
        }
    }
}
