using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge.Services
{
    public class CurlingService :ICurlingService
    {
        private readonly IXCoordinateGenerator _xCoordinateGenerator;

        public CurlingService(IXCoordinateGenerator xCoordinateGenerator)
        {
            _xCoordinateGenerator = xCoordinateGenerator;
        }

        public void Start(int numberOfDiscs, int radius, out Plane plane)
        {
            plane = new Plane();
            while (numberOfDiscs > 0)
            {
                var x = _xCoordinateGenerator.GenerateX();
                if (plane.IsEmpty)
                {
                    plane.InitializeAt(x, radius);
                }
                else
                {
                    plane.PlaceDiscAt(x);
                }
                numberOfDiscs--;
            }
        }
    }
}
