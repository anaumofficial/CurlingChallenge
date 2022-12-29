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

        public Disc(int radius, Point center)
        {
            Center = center;
            Radius = radius;
        }

        public void MoveTo(Point center)
        {
            Center = center;
        }
    }
}
