using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge.Services
{
    public class XCoordinateGenerator :IXCoordinateGenerator
    {
        public double GenerateX()
        {
            int x = new Random().Next(1, 1000);
            return x;
        }
    }
}
