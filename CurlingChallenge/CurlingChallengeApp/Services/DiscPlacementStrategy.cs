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
        private readonly IXCoordinateGenerator _xCoordinateGenerator;

        public DiscPlacementStrategy(Plane plane, ICoordinatesCalculator coordinatesCalculator, IXCoordinateGenerator xCoordinateGenerator)
        {
            _plane = plane;
            _coordinatesCalculator = coordinatesCalculator;
            _xCoordinateGenerator = xCoordinateGenerator;
        }

        internal Point Place(Disc disc)
        {
            var x = _xCoordinateGenerator.GenerateX();
            if (_plane.IsEmpty)
            {
                return new Point(x, disc.Radius);
            }
            else
            {
                var count = _plane.PlacedDiscs.Count();
                for (var i = count - 1; i >= 0; i--)
                {
                    var lastDisc = _plane.PlacedDiscs[i];
                    var center = _coordinatesCalculator.CalculateCenter(lastDisc.Center, x, disc.Radius);
                    if (center == null)
                    {
                        if (i == 0)
                        {
                            return new Point(x, disc.Radius);
                        }
                        continue;
                    }
                    else
                    {
                        return center;
                    }
                }
                return new Point(x, disc.Radius);
            }
        }
    }
}
