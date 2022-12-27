using CurlingChallenge.Models;

namespace CurlingChallenge.Services.Interfaces
{
    public interface ICoordinatesCalculator
    {
        Point CalculateCenterPoint(Point center, int radius, double x);
        Point CalculateFirstCenterPoint(Point startingPoint, int radius);
    }
}