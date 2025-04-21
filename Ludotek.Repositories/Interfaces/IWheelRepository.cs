using Ludotek.Repositories.Models;

namespace Ludotek.Repositories.Interfaces
{
    public interface IWheelRepository
    {
        Task<Wheel> GetWheel(string nomRoue);
    }
}