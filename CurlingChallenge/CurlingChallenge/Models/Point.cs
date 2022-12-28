namespace CurlingChallenge.Models
{
    public class Point
    {
        public double X
        {
            get; private set;
        }

        public double Y
        {
            get; private set;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void InitCenter(int radius, out Point center)
        {
            center = new Point(X, Y + radius);
        }

        public bool TryFindNextCenter(int radius, double x, out Point nextCenter)
        {
            var pythagoreanEquation = 4.0 * Math.Pow(radius, 2) - Math.Pow(x - X, 2);
            if (pythagoreanEquation >= 0)
            {
                var y = Y + Math.Sqrt(pythagoreanEquation);
                nextCenter = new Point(x, Math.Round(y, 11, MidpointRounding.AwayFromZero));
                return true;
            }
            else
            {
                nextCenter = null;
                return false;
            }
        }
    }
}
