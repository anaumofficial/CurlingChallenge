namespace CurlingChallenge.Models
{
    public class Plane
    {
        private IList<Disc> PlacedDiscs
        {
            get; set;
        }

        public bool NoDiscPlaced => !PlacedDiscs.Any();
        public Plane()
        {
            PlacedDiscs = new List<Disc>();
        }

        public IEnumerable<double> GetAllYCoordinates()
        {
            return PlacedDiscs.Select(x => x.Center.Y);
        }

        public void InitializeAt(double x, int radius)
        {
            var disc = new Disc(radius);
            disc.InitializeAt(x);
            PlacedDiscs.Add(disc);
        }

        public void TryPlaceNextDiscAt(double x)
        {
            var count = PlacedDiscs.Count();
            for (var i = count - 1; i >= 0; i--)
            {
                var lastDiscCenter = PlacedDiscs[i];
                lastDiscCenter.Center.TryGetNextCenterPoint(lastDiscCenter.Radius, x, out Point center);
                if (center == null)
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
                    disc.TryPlaceAt(center);
                    PlacedDiscs.Add(disc);
                    break;
                }
            }
        }
    }
}
