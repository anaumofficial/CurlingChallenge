using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge.Services
{
    public class XCoordinateGeneratorWithStaticOutput :IXCoordinateGenerator
    {
        public int[] staticXCoordinates = new int[] { 5, 5, 6, 8, 3, 12 };
        public int CurrentIndex
        {
            get; set;
        }

        public double GenerateX()
        {
            var x = staticXCoordinates[CurrentIndex];
            CurrentIndex++;
            return x;
        }
    }
}
