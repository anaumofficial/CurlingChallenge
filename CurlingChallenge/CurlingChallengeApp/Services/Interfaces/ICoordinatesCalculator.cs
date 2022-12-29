using CurlingChallenge.Models;

namespace CurlingChallengeApp.Services.Interfaces
{
    public interface ICoordinatesCalculator
    {
        Point CalculateCenter(Point center, double x, int radius);
    }
}
