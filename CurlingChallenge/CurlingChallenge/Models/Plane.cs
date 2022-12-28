namespace CurlingChallenge.Models
{
    public class Plane
    {
        private IList<Disc> PlacedDiscs
        {
            get; set;
        }

        public bool IsEmpty => !PlacedDiscs.Any();

        public Plane()
        {
            PlacedDiscs = new List<Disc>();
        }

        public IEnumerable<Point> GetCoordinates()
        {
            return PlacedDiscs.Select(x => x.Center);
        }

        public void InitializeAt(double x, int radius)
        {
            var disc = new Disc(radius);
            new Point(x, 0).InitCenter(radius, out Point center);
            disc.MoveTo(center);
            PlacedDiscs.Add(disc);
        }

        public void PlaceDiscAt(double x)
        {
            var count = PlacedDiscs.Count();
            for (var i = count - 1; i >= 0; i--)
            {
                var lastDiscCenter = PlacedDiscs[i];
                var successful = lastDiscCenter.Center.TryFindNextCenter(lastDiscCenter.Radius, x, out Point center);
                if (!successful)
                {
                    if (i == 0)
                    {
                        InitializeAt(x, lastDiscCenter.Radius);
                    }
                    continue;
                }
                else
                {
                    var disc = new Disc(lastDiscCenter.Radius);
                    disc.MoveTo(center);
                    PlacedDiscs.Add(disc);
                    break;
                }
            }
        }
    }
}
