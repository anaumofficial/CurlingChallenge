using CurlingChallenge.Models;
using CurlingChallengeApp.Services.Interfaces;
using System;
using System.Linq;

namespace CurlingChallengeApp.Services
{
    public class CarolDiscPlacementStrategy :IDiscPlacementStrategy
    {
        private Plane Plane
        {
            get; set;
        }

        public void Init(Plane plane)
        {
            Plane = plane;
        }

        public Point Place(Disc disc)
        {
            if (Plane.IsEmpty)
            {
                return new Point(disc.Center.X, disc.Radius);
            }
            else
            {
                var count = Plane.PlacedDiscs.Count();
                for (var i = count - 1; i >= 0; i--)
                {
                    var lastDisc = Plane.PlacedDiscs[i];
                    var center = CalculateCenter(lastDisc.Center, disc.Center.X, disc.Radius);
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

        private Point CalculateCenter(Point center, double x, int radius)
        {
            var pythagoreanEquation = 4.0 * Math.Pow(radius, 2) - Math.Pow(x - center.X, 2);
            if (pythagoreanEquation >= 0)
            {
                var y = center.Y + Math.Sqrt(pythagoreanEquation);
                return new Point(x, Math.Round(y, 11, MidpointRounding.AwayFromZero));
            }
            return null;
        }
    }
}
