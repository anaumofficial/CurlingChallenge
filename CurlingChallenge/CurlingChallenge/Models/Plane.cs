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
                var lastDisc = PlacedDiscs[i];
                var successful = lastDisc.Center.TryFindNextCenter(lastDisc.Radius, x, out Point center);
                if (!successful)
                {
                    if (i == 0)
                    {
                        InitializeAt(x, lastDisc.Radius);
                    }
                    continue;
                }
                else
                {
                    var disc = new Disc(lastDisc.Radius);
                    disc.MoveTo(center);
                    PlacedDiscs.Add(disc);
                    break;
                }
            }
        }
    }
}
