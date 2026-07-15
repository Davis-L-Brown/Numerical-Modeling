using System;

namespace Approximation.Exceptions
{
    /// <summary>
    /// Represents an exception when a triangle is considered a degenerate triangle.
    /// </summary>
    public sealed class DegenerateTriangleException : Exception
    {
        public DegenerateTriangleException(string message)
            : base(message) { }
    }
}
