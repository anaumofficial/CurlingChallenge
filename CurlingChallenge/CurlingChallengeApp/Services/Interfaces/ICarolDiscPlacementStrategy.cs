using CurlingChallenge.Models;

namespace CurlingChallengeApp.Services.Interfaces
{
    public interface IDiscPlacementStrategy
    {
        Point Place(Disc disc);
    }
}