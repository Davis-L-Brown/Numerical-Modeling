using System;

namespace Interpolant.Configuration.Interpolation.Simplicial
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using simplicial interpolation. 
    /// </summary>
    public sealed class SimplicialOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.Simplicial;

        /// <summary>
        /// Get the <see cref="SimplicialOrder"/> specified by the consumer.
        /// </summary>
        public SimplicialOrder Order { get; }


        /// <summary>
        /// Creates a new instance of <see cref="SimplicialOptions"/>.
        /// </summary>
        public SimplicialOptions(
            SimplicialOrder order = SimplicialOrder.Linear)
        {
            Order = order;

            Validate();
        }


        /// <inheritdoc/>
        public void Validate()
        {
            if (!Enum.IsDefined(typeof(SimplicialOrder), Order))
            {
                throw new ArgumentOutOfRangeException(nameof(Order));
            }
        }
    }
}
