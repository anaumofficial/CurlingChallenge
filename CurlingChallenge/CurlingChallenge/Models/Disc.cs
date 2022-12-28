namespace CurlingChallenge.Models
{
    public class Disc
    {
        public int Radius
        {
            get; private set;
        }

        public Point Center
        {
            get; private set;
        }

        public Disc(int radius)
        {
            Radius = radius;
        }

        public void InitializeAt(double x)
        {
            new Point(x, 0).InitCenter(Radius, out Point center);
            Center = center;
        }

        public void SetCenterAt(Point center)
        {
            Center = center;
        }
    }
}
