using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters {
    /// <summary>
    /// Inverts a <see cref="bool"/> and converts the result into recent <see cref="Visibility"/> and vice versa.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InvertedBooleanToVisibilityConverter : IValueConverter {
        /// <summary>
        /// Inverts <see cref="bool"/> and converts result into recent <see cref="Visibility"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/></param>
        /// <param name="targetType">UNUSED</param>
        /// <param name="parameter">Optional specification of <see cref="false"/>-state.</param>
        /// <param name="culture">UNUSED</param>
        /// <returns>
        /// <paramref name="parameter"/> or <see cref="Visibility.Collapsed"/> if not specified if <see cref="bool"/> is <see cref="true"/>.
        /// Else <see cref="Visibility.Visible"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as bool?) switch {
                true => BooleanToVisibilityConverter.TryParseVisibility(parameter, out Visibility vis) ? vis : Visibility.Collapsed,
                _ => Visibility.Visible
            };
        }

        /// <summary>
        /// Converts <see cref="Visibility"/> into recent <see cref="bool"/> and inverts the result.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/></param>
        /// <param name="targetType">UNUSED</param>
        /// <param name="parameter">UNUSED</param>
        /// <param name="culture">UNUSED</param>
        /// <returns><see cref="true"/> if <paramref name="value"/> is not <see cref="Visibility.Visible"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as Visibility?) != Visibility.Visible;
        }
    }
}
