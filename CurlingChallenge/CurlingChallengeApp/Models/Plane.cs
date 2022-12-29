using System.Collections.Generic;
using System.Linq;

namespace CurlingChallenge.Models
{
    public class Plane
    {
        internal IList<Disc> PlacedDiscs
        {
            get; private set;
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

        public void AddDisc(Disc dics)
        {
        }
    }
}
