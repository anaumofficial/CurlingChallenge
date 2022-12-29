using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;
using CurlingChallengeApp.Services;
using CurlingChallengeApp.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace CurlingChallenge.Services
{
    public class CurlingService :ICurlingService
    {
        private readonly ICoordinatesCalculator _coordinatesCalculator;
        private readonly IXCoordinateGenerator _xCoordinateGenerator;

        public CurlingService(ICoordinatesCalculator coordinatesCalculator, IXCoordinateGenerator xCoordinateGenerator)
        {
            _coordinatesCalculator = coordinatesCalculator;
            _xCoordinateGenerator = xCoordinateGenerator;
        }

        public void Start(int numberOfDiscs, int radius, out Plane plane)
        {
            plane = new Plane();
            var strategy = new DiscPlacementStrategy(plane, _coordinatesCalculator, _xCoordinateGenerator);
            foreach (var disc in Discs(numberOfDiscs, radius))
            {
                var centerPoint = strategy.Place(disc);
                disc.MoveTo(centerPoint);
                plane.PlacedDiscs.Add(disc);
            }
        }

        private IEnumerable<Disc> Discs(int numberOfDiscs, int radius)
        {
            var discs = new List<Disc>();
            while (numberOfDiscs > 0)
            {
                discs.Add(new Disc(radius));
                numberOfDiscs--;
            }
            return discs;
        }
    }
}
