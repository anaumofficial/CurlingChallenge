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
            MoveTo(center);
        }

        public void MoveTo(Point center)
        {
            Center = center;
        }


        public bool TryPlaceNextDiscAt(double x, out Disc disc)
        {
            var success = Center.TryFindNextCenter(Radius, x, out Point center);
            if (success)
            {
                disc = new Disc(Radius);
                disc.MoveTo(center);
                return success;
            }
            disc = null;
            return false;
        }
    }
}
