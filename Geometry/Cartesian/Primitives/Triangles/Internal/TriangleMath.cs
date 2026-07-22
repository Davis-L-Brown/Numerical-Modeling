using Geometry.Quantities.Angles;
using System;

namespace Geometry.Cartesian.Primitives.Triangles.Internal
{
    public static class TriangleMath
    {
        /// <summary>
        /// Hepler used to get an angle in the triangle.
        /// </summary>
        /// <remarks>
        /// Uses the law of cosines to calculate the edge.
        /// </remarks>
        /// <param name="leftAdjacentLength">
        /// The length of the edge left-adjacent to the angle being calculated.
        /// </param>
        /// <param name="rightAdjacentLength">
        /// The length of the edge right-adjacent to the angle being calculated.
        /// </param>
        /// <param name="oppositeLength">
        /// The length of the edge opposite the angle being calculated.
        /// </param>
        /// <returns>
        /// The calculated angle.
        /// </returns>
        public static Angle GetInteriorAngle(
            double leftAdjacentLength,
            double rightAdjacentLength,
            double oppositeLength)
        {
            if (oppositeLength >= leftAdjacentLength + rightAdjacentLength)
                throw new ArgumentException(
                    "The supplied edge lengths form a degenerate triangle: " +
                    $"{oppositeLength} > = {leftAdjacentLength} + {rightAdjacentLength}");

            double cosine =
                (leftAdjacentLength * leftAdjacentLength +
                 rightAdjacentLength * rightAdjacentLength -
                 oppositeLength * oppositeLength) /
                (2.0 * leftAdjacentLength * rightAdjacentLength);

            cosine = Math.Min(1.0, Math.Max(-1.0, cosine));

            return Angle.FromRadians(Math.Acos(cosine));
        }
    }
}
