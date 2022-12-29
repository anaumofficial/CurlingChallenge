using CurlingChallenge.Models;

namespace CurlingChallengeApp.Services.Interfaces
{
    public interface IDiscPlacementStrategy
    {
        void Init(Plane plane);
        Point Place(Disc disc);
    }
}