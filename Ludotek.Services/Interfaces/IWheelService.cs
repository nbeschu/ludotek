using Ludotek.Services.Dto;

namespace Ludotek.Services.Interfaces
{
    public interface IWheelService
    {
        Task<WheelDto> GetWheel(string nomRoue);
    }
}