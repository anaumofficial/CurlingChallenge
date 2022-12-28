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
                var lastDiscCenter = PlacedDiscs[i];
                var successful = lastDiscCenter.Center.TryGetNextCenterPoint(lastDiscCenter.Radius, x, out Point center);
                if (!successful)
                {
                    if (i == 0)
                    {
                        var disc = new Disc(lastDiscCenter.Radius);
                        disc.InitializeAt(x);
                        PlacedDiscs.Add(disc);
                    }
                    continue;
                }
                else
                {
                    var disc = new Disc(lastDiscCenter.Radius);
                    disc.SetCenterAt(center);
                    PlacedDiscs.Add(disc);
                    break;
                }
            }
        }
    }
}
