using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge.Services
{
    public class CurlingService :ICurlingService
    {
        private readonly IXCoordinateGenerator _xCoordinateGenerator;
        private readonly ICoordinatesCalculator _coordinatesCalculator;

        public CurlingService(IXCoordinateGenerator xCoordinateGenerator, ICoordinatesCalculator coordinatesCalculator)
        {
            _xCoordinateGenerator = xCoordinateGenerator;
            _coordinatesCalculator = coordinatesCalculator;
        }

        public Plane Start(int discNumber, int radius)
        {
            var plane = new Plane();
            while (discNumber > 0)
            {
                var x = _xCoordinateGenerator.GenerateX();
                if (!plane.PlacedDiscs.Any())
                {
                    var center = _coordinatesCalculator.CalculateFirstCenterPoint(new Point(x, 0), radius);
                    var disc = new Disc(radius, center);
                    plane.PlacedDiscs.Add(disc);
                }
                else
                {
                    var count = plane.PlacedDiscs.Count();
                    for (var i = count - 1; i >= 0; i--)
                    {
                        var lastDiscCenter = plane.PlacedDiscs[i];
                        var center = _coordinatesCalculator.CalculateCenterPoint(lastDiscCenter.Center, radius, x);
                        if (center == null)
                        {
                            if (i == 0)
                            {
                                center = _coordinatesCalculator.CalculateFirstCenterPoint(new Point(x, 0), radius);
                                var disc = new Disc(radius, center);
                                plane.PlacedDiscs.Add(disc);
                            }
                            continue;
                        }
                        else
                        {
                            var disc = new Disc(radius, center);
                            plane.PlacedDiscs.Add(disc);
                            break;
                        }
                    }
                }
                discNumber--;
            }
            return plane;
        }
    }
}
