using CurlingChallenge.Models;

namespace CurlingChallenge.Services.Interfaces
{
    public interface ICurlingService
    {
        void Start(int discNumber, int radius, out Plane plane);
    }
}