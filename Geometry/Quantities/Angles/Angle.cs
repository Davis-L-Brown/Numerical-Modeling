using System;

namespace Geometry.Quantities.Angles
{
    public readonly struct Angle : IEquatable<Angle>, IComparable<Angle>
    {
        public double Radians { get; }
        public double Revolutions => Radians / (2 * Math.PI);
        public double Degrees => Radians * 180 / Math.PI;
        public double ArcMinutes => Radians * 10800 / Math.PI;
        public double ArcSeconds => Radians * 648000 / Math.PI;
        public double Gradians => Radians * 200 / Math.PI;

        private Angle(double value)
        {
            Radians = value;
        }

        #region constructors
        public static Angle Zero => new Angle(0);
        public static Angle Pi => new Angle(Math.PI);
        public static Angle Tau => new Angle(Math.PI * 2);
        public static Angle FromRadians(double radians) => new Angle(radians);
        public static Angle FromRevolutions(double revolutions) => new Angle(revolutions * 2 * Math.PI);
        public static Angle FromDegrees(double degrees) => new Angle(degrees * Math.PI / 180);
        public static Angle FromArcMinutes(double arcminutes) => new Angle(arcminutes * Math.PI / 10800);
        public static Angle FromArcSeconds(double arcSeconds) => new Angle(arcSeconds * Math.PI / 648000);
        public static Angle FromGradians(double gradians) => new Angle(gradians * Math.PI / 200);
        #endregion


        #region operators

        #region equality operators
        #region exact equality
        public override int GetHashCode() => Radians.GetHashCode();
        public bool Equals(Angle other) => Radians.Equals(other.Radians);
        public override bool Equals(object obj) => obj is Angle other && Equals(other);

        public static bool operator ==(Angle a, Angle b) => a.Equals(b);
        public static bool operator !=(Angle a, Angle b) => !a.Equals(b);
        public static bool operator <(Angle a, Angle b) => a.Radians < b.Radians;
        public static bool operator <=(Angle a, Angle b) => a.Radians <= b.Radians;
        public static bool operator >(Angle a, Angle b) => a.Radians > b.Radians;
        public static bool operator >=(Angle a, Angle b) => a.Radians >= b.Radians;
        #endregion

        #region relative equality
        public bool NearlyEquals(
            Angle other,
            double absoluteTolerance = 1e-12,
            double relativeTolerance = 1e-12)
        {
            double diff = Math.Abs(Radians - other.Radians);
            double maxRadians = Math.Max(Math.Abs(Radians), Math.Abs(other.Radians));
            double max = Math.Max(absoluteTolerance, relativeTolerance * maxRadians);
            return diff <= max;
        }

        public static bool NearlyEquals(
            Angle a,
            Angle b,
            double absoluteTolerance = 1e-12,
            double relativeTolerance = 1e-12)
            => a.NearlyEquals(b, absoluteTolerance, relativeTolerance);

        #endregion
        #endregion

        #region arithmetic operators
        public int CompareTo(Angle other) => Radians.CompareTo(other.Radians);
        public static Angle operator +(Angle a, Angle b) => FromRadians(a.Radians + b.Radians);
        public static Angle operator -(Angle a, Angle b) => FromRadians(a.Radians - b.Radians);
        public static Angle operator *(Angle a, double b) => FromRadians(a.Radians * b);
        public static Angle operator *(double b, Angle a) => FromRadians(a.Radians * b);
        public static Angle operator /(Angle a, double b) => FromRadians(a.Radians / b);
        public static double operator /(Angle a, Angle b) => a.Radians / b.Radians;
        #endregion

        #endregion
    }
}
