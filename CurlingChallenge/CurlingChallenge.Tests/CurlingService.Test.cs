using CurlingChallenge.Services;

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
            var curling  = new CurlingService(coordinatesGenerator, coordinatesCalculator);
            var result = curling.Start(count, radius);
            Assert.That(result.GetAllYCoordinates(), Is.EqualTo(expected).Within(0.0000000001));
        }
    }
}