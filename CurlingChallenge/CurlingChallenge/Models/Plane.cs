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
            disc.InitializeAt(x);
            PlacedDiscs.Add(disc);
        }

        public void PlaceDiscAt(double x)
        {
            var count = PlacedDiscs.Count();
            for (var i = count - 1; i >= 0; i--)
            {
                var lastDisc = PlacedDiscs[i];
                var successful = lastDisc.TryPlaceNextDiscAt(x, out Disc disc);
                if (successful)
                {
                    PlacedDiscs.Add(disc);
                    break;
                }
                else
                {
                    if (i == 0)
                    {
                        InitializeAt(x, lastDisc.Radius);
                    }
                    continue;
                }
            }
        }
    }
}
