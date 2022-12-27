namespace CurlingChallenge.Models
{
    public class Plane
    {
        public IList<Disc> PlacedDiscs
        {
            get; private set;
        }
        public Plane()
        {
            PlacedDiscs = new List<Disc>();
        }

        public IEnumerable<double> GetAllYCoordinates()
        {
            return PlacedDiscs.Select(x => x.Center.Y);
        }
    }
}
