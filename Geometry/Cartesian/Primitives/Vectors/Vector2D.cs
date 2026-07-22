using Geometry.Cartesian.Points;
using System;

namespace Geometry.Cartesian.Primitives.Vectors
{
    /// <summary>
    /// Defines a vector in 2D Cartesian space.
    /// </summary>
    public class Vector2D : IVector2D, IEquatable<Vector2D>
    {
        /// <inheritdoc/>
        public double X { get; }

        /// <inheritdoc/>
        public double Y { get; }

        /// <inheritdoc/>
        public double Magnitude => 
            Math.Sqrt(MagnitudeSquared);

        /// <summary>
        /// Get the squared Magnitude.
        /// </summary>
        public double MagnitudeSquared => 
            (X * X) + (Y * Y);

        
        /// <summary>
        /// Creates a new instance of <see cref="Vector2D"/>.
        /// </summary>
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Creates a new instance of <see cref="Vector2D"/>
        /// from two <see cref="IPoint2D"/>.
        /// </summary>
        public static Vector2D FromPoints(
            IPoint2D start,
            IPoint2D end)
        {
            return new Vector2D(
                end.X - start.X,
                end.Y - start.Y);
        }


        #region Operators
        /// <summary>
        /// Returns a normalized copy of the vector.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the vector has zero magnitude.
        /// </exception>
        public Vector2D Normalize()
        {
            double magnitude = Magnitude;

            if (magnitude == 0.0)
                throw new InvalidOperationException(
                    "A zero vector cannot be normalized.");

            return this / magnitude;
        }

        /// <summary>
        /// Calculate the dot product of two 2D vectors.
        /// </summary>
        public static double Dot(Vector2D left, Vector2D right)
        {
            return
                (left.X * right.X) +
                (left.Y * right.Y);
        }

        /// <summary>
        /// Calculates the scalar two-dimensional cross product.
        /// </summary>
        /// <remarks>
        /// The result is the Z component of the corresponding
        /// three-dimensional cross product.
        /// </remarks>
        public static double Cross(Vector2D left, Vector2D right)
        {
            return
                (left.X * right.Y) -
                (left.Y * right.X);
        }


        #region Vector addition/subtraction
        /// <summary>
        /// Add two vectors.
        /// </summary>
        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            return new Vector2D(
                left.X + right.X,
                left.Y + right.Y);
        }

        /// <summary>
        /// Subtract two vectors.
        /// </summary>
        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            return new Vector2D(
                left.X - right.X,
                left.Y - right.Y);
        }

        /// <summary>
        /// Multiply by negative 1.
        /// </summary>
        public static Vector2D operator -(Vector2D vector)
        {
            return new Vector2D(-vector.X, -vector.Y);
        }
        #endregion

        #region Scalar Multiply/Divide
        /// <summary>
        /// Multiply a vector by a scalar.
        /// </summary>
        public static Vector2D operator *(Vector2D vector, double scalar)
        {
            return new Vector2D(
                vector.X * scalar,
                vector.Y * scalar);
        }

        /// <summary>
        /// Multiply a vector by a scalar.
        /// </summary>
        public static Vector2D operator *(double scalar, Vector2D vector)
        {
            return vector * scalar;
        }

        /// <summary>
        /// Divide a vector by a scalar.
        /// </summary>
        public static Vector2D operator /(Vector2D vector, double scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException(
                    "A vector cannot be divided by zero.");

            return new Vector2D(
                vector.X / scalar,
                vector.Y / scalar);
        }
        #endregion

        #region Equality
        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public static bool operator ==(Vector2D left, Vector2D right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare two vectors for inequality.
        /// </summary>
        public static bool operator !=(Vector2D left, Vector2D right)
        {
            return !(left.Equals(right));
        }

        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public bool Equals(Vector2D other)
        {
            return
                X.Equals(other.X) &&
                Y.Equals(other.Y);
        }

        /// <summary>
        /// Compare two vectors for equality.
        /// </summary>
        public override bool Equals(object other)
        {
            return
                other is Vector2D &&
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
                return hash;
            }
        }

        /// <summary>
        /// Get the vector as a string
        /// </summary>
        /// <returns>
        /// A string in the format &lt;X, Y&gt;
        /// </returns>
        public override string ToString()
        {
            return $"<{X}, {Y}>";
        }
    }
}
