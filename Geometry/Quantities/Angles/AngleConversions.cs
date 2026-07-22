using System;

namespace Geometry.Quantities.Angles
{
    /// <summary>
    /// A static class that allows the quick conversion of an angle's value from one unit to another
    /// </summary>
    public static class AngleConversion
    {
        /// <summary>
        /// Converts the <paramref name="value"/> of an angle from unit <paramref name="unitIn"/> to unit <paramref name="unitOut"/>
        /// </summary>
        /// <param name="value">The value of the angle in its current unit <paramref name="unitIn"/></param>
        /// <param name="unitIn">The unit (<see cref="AngleUnit"/>) the angle is in</param>
        /// <param name="unitOut">The unit (<see cref="AngleUnit"/>) the angle will be converted to</param>
        /// <returns>the numeric value of the angle in <paramref name="unitOut"/></returns>
        public static double Convert(double value, AngleUnit unitIn, AngleUnit unitOut) => FromRadians(ToRadians(value, unitIn), unitOut);

        #region To Radians
        /// <summary>
        /// Convert the <paramref name="value"/> of an angle from unit : <paramref name="unit"/> to Radians
        /// </summary>
        /// <param name="value">the value of the angle in its current unit: <paramref name="unit"/></param>
        /// <param name="unit">the unit (<see cref="AngleUnit"/>) the angle is in</param>
        /// <returns>The value numeric value of the angle in Radians</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double ToRadians(double value, AngleUnit unit)
        {
            switch (unit)
            {
                case AngleUnit.Radians:
                    return value;

                case AngleUnit.Revolutions:
                    return value * 2.0 * Math.PI;

                case AngleUnit.Degrees:
                    return value * Math.PI / 180.0;

                case AngleUnit.ArcMinutes:
                    return value * Math.PI / 10800.0;

                case AngleUnit.ArcSeconds:
                    return value * Math.PI / 648000.0;

                case AngleUnit.Gradians:
                    return value * Math.PI / 200.0;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(unit),
                        unit,
                        "The specified angle unit is not supported.");
            }
        }
        #endregion


        #region Radians to x
        /// <summary>
        /// Convert the <paramref name="radians"/> of an angle to unit (<paramref name="unit"/>)
        /// </summary>
        /// <param name="radians">The value of the angle in Radians</param>
        /// <param name="unit">The unit (<see cref="AngleUnit"/>) the angle will be converted to</param>
        /// <returns>The numeric value of the angle in unit <paramref name="unit"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a valid <see cref="AngleUnit"/> is not passed</exception>
        public static double FromRadians(double radians, AngleUnit unit)
        {
            switch (unit)
            {
                case AngleUnit.Radians:
                    return radians;

                case AngleUnit.Revolutions:
                    return radians / (2.0 * Math.PI);

                case AngleUnit.Degrees:
                    return radians * 180.0 / Math.PI;

                case AngleUnit.ArcMinutes:
                    return radians * 10800.0 / Math.PI;

                case AngleUnit.ArcSeconds:
                    return radians * 648000.0 / Math.PI;

                case AngleUnit.Gradians:
                    return radians * 200.0 / Math.PI;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(unit),
                        unit,
                        "The specified angle unit is not supported.");
            }
        }
        #endregion
    }
}
