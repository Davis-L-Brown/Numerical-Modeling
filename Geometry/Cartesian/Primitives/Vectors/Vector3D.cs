using Geometry.Cartesian.Points;
using System;

namespace Geometry.Cartesian.Primitives.Vectors
{
    /// <summary>
    /// Defines a vector in 3D Cartesian space.
    /// </summary>
    public class Vector3D : IVector3D, IEquatable<Vector3D>
    {
        /// <inheritdoc/>
        public double X { get; }

        /// <inheritdoc/>
        public double Y { get; }

        /// <inheritdoc/>
        public double Z { get; }

        /// <inheritdoc/>
        public double Magnitude =>
            Math.Sqrt(MagnitudeSquared);
        
        /// <summary>
        /// Get the squared Magnitude.
        /// </summary>
        public double MagnitudeSquared =>
            (X * X) + (Y * Y) + (Z * Z);


        /// <summary>
        /// Creates a new instance of <see cref="Vector3D"/>.
        /// </summary>
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Vector3D"/>
        /// from two <see cref="IPoint3D"/>.
        /// </summary>
        public static Vector3D FromPoints(
            IPoint3D start,
            IPoint3D end)
        {
            return new Vector3D(
                end.X - start.X,
                end.Y - start.Y,
                end.Z - start.Z);
        }


        #region Operators
        /// <summary>
        /// Returns a normalized copy of the vector.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the vector has zero magnitude.
        /// </exception>
        public Vector3D Normalize()
        {
            double magnitude = Magnitude;

            if (magnitude == 0.0)
                throw new InvalidOperationException(
                    "A zero vector cannot be normalized.");

            return this / magnitude;
        }

        /// <summary>
        /// Get the dot product of two vectors.
        /// </summary>
        public static double Dot(Vector3D left, Vector3D right)
        {
            return
                (left.X * right.X) +
                (left.Y * right.Y) + 
                (left.Z * right.Z);
        }

        /// <summary>
        /// Calculates the scalar two-dimensional cross product.
        /// </summary>
        /// <remarks>
        /// The result is the Z component of the corresponding
        /// three-dimensional cross product.
        /// </remarks>
        public static Vector3D Cross(Vector3D left, Vector3D right)
        {
            return new Vector3D(
                (left.Y * right.Z) - (left.Z * right.Y),
                (left.Z * right.X) - (left.X * right.Z),
                (left.X * right.Y) - (left.Y * right.X));
        }


        #region Vector addition/subtraction
        /// <summary>
        /// Add two vectors.
        /// </summary>
        public static Vector3D operator +(Vector3D left, Vector3D right)
        {
            return new Vector3D(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z);
        }

        /// <summary>
        /// Subtract two vectors.
        /// </summary>
        public static Vector3D operator -(Vector3D left, Vector3D right)
        {
            return new Vector3D(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z);
        }

        /// <summary>
        /// Multiply by negative 1.
        /// </summary>
        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-vector.X, -vector.Y, -vector.Z);
        }
        #endregion

        #region Scalar Multiply/Divide
        /// <summary>
        /// Multiply a vector by a scalar.
        /// </summary>
        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(
                vector.X * scalar,
                vector.Y * scalar,
                vector.Z * scalar);
        }

        /// <summary>
        /// Multiply a vector by a scalar.
        /// </summary>
        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            return vector * scalar;
        }

        /// <summary>
        /// Divide a vector by a scalar.
        /// </summary>
        public static Vector3D operator /(Vector3D vector, double scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException(
                    "A vector cannot be divided by zero.");

            return new Vector3D(
                vector.X / scalar,
                vector.Y / scalar,
                vector.Z / scalar);
        }
        #endregion

        #region Equality
        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public static bool operator ==(Vector3D left, Vector3D right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare two vectors for inequality.
        /// </summary>
        public static bool operator !=(Vector3D left, Vector3D right)
        {
            return !(left.Equals(right));
        }

        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public bool Equals(Vector3D other)
        {
            return
                X.Equals(other.X) &&
                Y.Equals(other.Y) &&
                Z.Equals(other.Z);
        }

        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public override bool Equals(object other)
        {
            return
                other is Vector3D &&
                Equals(other);
        }
        #endregion

        #endregion


        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 31) + X.GetHashCode();
                hash = (hash * 31) + Y.GetHashCode();
                hash = (hash * 31) + Z.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Get the vector as a string
        /// </summary>
        /// <returns>
        /// A string in the format &lt;X, Y, Z&gt;
        /// </returns>
        public override string ToString()
        {
            return $"<{X}, {Y}, {Z}>";
        }
    }
}
