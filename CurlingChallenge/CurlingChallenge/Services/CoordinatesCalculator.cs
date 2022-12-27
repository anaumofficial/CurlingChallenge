using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge.Services
{
    public class CoordinatesCalculator :ICoordinatesCalculator
    {
        public Point CalculateFirstCenterPoint(Point startingPoint, int radius)
        {
            return new Point(startingPoint.X, startingPoint.Y + radius);
        }

        public Point CalculateCenterPoint(Point center, int radius, double x)
        {
            if (4.0 * radius * radius - (x - center.X) * (x - center.X) < 0)
            {
                return null;
            }

            var Y = center.Y + Math.Sqrt(4.0 * radius * radius - (x - center.X) * (x - center.X));
            return new Point(x, Math.Round(Y, 11, MidpointRounding.ToEven));
        }
    }
}
