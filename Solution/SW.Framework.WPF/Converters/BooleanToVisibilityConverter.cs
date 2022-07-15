using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters {
    /// <summary>
    /// Converts <see cref="bool"/> into recent <see cref="Visibility"/> and vice versa.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter {
        /// <summary>
        /// Converts <see cref="bool"/> into recent <see cref="Visibility"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/></param>
        /// <param name="targetType">UNUSED</param>
        /// <param name="parameter">Optional specification of <see cref="false"/>-state.</param>
        /// <param name="culture">UNUSED</param>
        /// <returns>
        /// <see cref="Visibility.Visible"/> if <see cref="bool"/> is <see cref="true"/>.
        /// Else value of <paramref name="parameter"/> or <see cref="Visibility.Collapsed"/> if not specified.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as bool?) switch {
                true => Visibility.Visible,
                _ => TryParseVisibility(parameter, out Visibility vis) ? vis : Visibility.Collapsed
            };
        }

        /// <summary>
        /// Converts <see cref="Visibility"/> into recent <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/></param>
        /// <param name="targetType">UNUSED</param>
        /// <param name="parameter">UNUSED</param>
        /// <param name="culture">UNUSED</param>
        /// <returns><see cref="true"/> if <paramref name="value"/> is <see cref="Visibility.Visible"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as Visibility?) == Visibility.Visible;
        }

        internal static bool TryParseVisibility(object value, out Visibility visibility) {
            if (value is Visibility vis || Enum.TryParse(value.ToString(), true, out vis)) {
                visibility = vis;
                return true;
            }

            visibility = Visibility.Collapsed;
            return false;
        }
    }
}
