using CurlingChallenge.Models;
using CurlingChallenge.Services;
using CurlingChallengeApp.Services;

namespace CurlingChallenge.Tests
{
    public class Tests
    {
        [TestCase(6, 2)]
        public void ShouldReturnY(int count, int radius)
        {
            var expected = new double[] { 2, 6.0, 9.87298334621, 13.3370849613, 12.5187346573, 13.3370849613 }.ToList();
            var coordinatesGenerator = new XCoordinateGeneratorWithStaticOutput();
            var coordinatesCalculator = new CoordinatesCalculator();
            var curling = new CurlingService(coordinatesCalculator, coordinatesGenerator);
            curling.Start(count, radius, out Plane result);
            Assert.That(result.GetCoordinates().Select(x => x.Y), Is.EqualTo(expected).Within(0.0000000001));
        }
    }
}