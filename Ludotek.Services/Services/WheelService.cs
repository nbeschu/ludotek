using AutoMapper;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Ludotek.Services.Interfaces;
using Microsoft.Extensions.Localization;

namespace Ludotek.Services.Services
{
    public class WheelService : BaseService<WheelService>, IWheelService
    {
        /// <summary>
        /// Le Repository Wheel
        /// </summary>
        private readonly IWheelRepository _wheelRepositoy;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public WheelService(
            IStringLocalizer<WheelService> localizer,
            IMapper mapper,
            IWheelRepository wheelRepository) : base(localizer, mapper)
        {
            _wheelRepositoy = wheelRepository;
        }

        /// <summary>
        /// Récupère une roue
        /// </summary>
        /// <returns>La roue ainsi trouvée</returns>
        public async Task<WheelDto> GetWheel(string nomRoue)
        {
            if (string.IsNullOrWhiteSpace(nomRoue))
            {
                throw new ArgumentNullException(nameof(nomRoue));
            }

            try
            {
                Wheel wheel = await _wheelRepositoy.GetWheel(nomRoue);
                wheel.Config.Entries = wheel.Config.Entries.FindAll(e => e.Text != "Je relance la roue" && e.Text != "Je paye mon sub");

                WheelDto wheelDto = _mapper.Map<WheelDto>(wheel);

                return wheelDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de la roue : {ex.Message}");
                throw;
            }
        }
    }
}
