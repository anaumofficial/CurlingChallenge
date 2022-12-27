using CurlingChallenge.Models;

namespace CurlingChallenge.Services.Interfaces
{
    public interface ICurlingService
    {
        Plane Start(int discNumber, int radius);
    }
}