using CurlingChallenge.Models;

namespace CurlingChallenge.Services.Interfaces
{
    public interface IPlaneRepository
    {
        Plane Get();
        void Save(Plane plane);
    }
}
