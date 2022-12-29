using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;
using CurlingChallengeApp.Services.Interfaces;
using System.Linq;

namespace CurlingChallengeApp.Services
{
    public class DiscPlacementStrategy
    {
        private readonly Plane _plane;
        private readonly ICoordinatesCalculator _coordinatesCalculator;

        public DiscPlacementStrategy(Plane plane, ICoordinatesCalculator coordinatesCalculator)
        {
            _plane = plane;
            _coordinatesCalculator = coordinatesCalculator;
        }

        internal Point Place(Disc disc)
        {
            if (_plane.IsEmpty)
            {
                return new Point(disc.Center.X, disc.Radius);
            }
            else
            {
                var count = _plane.PlacedDiscs.Count();
                for (var i = count - 1; i >= 0; i--)
                {
                    var lastDisc = _plane.PlacedDiscs[i];
                    var center = _coordinatesCalculator.CalculateCenter(lastDisc.Center, disc.Center.X, disc.Radius);
                    if (center == null)
                    {
                        if (i == 0)
                        {
                            return new Point(disc.Center.X, disc.Radius);
                        }
                        continue;
                    }
                    else
                    {
                        return center;
                    }
                }
                return new Point(disc.Center.X, disc.Radius);
            }
        }
    }
}
