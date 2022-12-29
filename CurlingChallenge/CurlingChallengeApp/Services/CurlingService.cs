using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;
using CurlingChallengeApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CurlingChallenge.Services
{
    public class CurlingService :ICurlingService
    {
        private readonly IDiscPlacementStrategy _strategy;
        private readonly IXCoordinateGenerator _xCoordinateGenerator;

        public CurlingService(IDiscPlacementStrategy strategy, IXCoordinateGenerator xCoordinateGenerator)
        {
            _strategy = strategy;
            _xCoordinateGenerator = xCoordinateGenerator;
        }

        public void Start(int numberOfDiscs, int radius, out Plane plane)
        {
            plane = new Plane();
            _strategy.Init(plane);
            foreach (var disc in Discs(numberOfDiscs, radius))
            {
                var centerPoint = _strategy.Place(disc);
                disc.MoveTo(centerPoint);
                plane.AddDisc(disc);
            }
        }

        private IEnumerable<Disc> Discs(int numberOfDiscs, int radius)
        {
            while (numberOfDiscs > 0)
            {
                var x = _xCoordinateGenerator.GenerateX();
                yield return new Disc(radius, new Point(x, Math.Pow(10, 100)));
                numberOfDiscs--;
            }
        }
    }
}
