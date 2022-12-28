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

        public void TryGetNextCenterPoint(int radius, double x, out Point nextCenter)
        {
            var pythagoreanEquation = 4.0 * radius * radius - (x - X) * (x - X);
            if (pythagoreanEquation >= 0)
            {
                var y = Y + Math.Sqrt(pythagoreanEquation);
                nextCenter = new Point(x, Math.Round(y, 11, MidpointRounding.AwayFromZero));
            }
            else
                nextCenter = null;
        }
    }
}
