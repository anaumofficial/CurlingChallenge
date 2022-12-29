using CurlingChallenge.Models;
using CurlingChallengeApp.Services.Interfaces;
using System;

namespace CurlingChallengeApp.Services
{
    public class CoordinatesCalculator :ICoordinatesCalculator
    {
        public Point CalculateCenter(Point center, double x, int radius)
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
