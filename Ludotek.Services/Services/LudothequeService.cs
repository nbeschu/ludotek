using AutoMapper;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Ludotek.Services.Interfaces;
using Microsoft.Extensions.Localization;

namespace Ludotek.Services.Services
{
    public class LudothequeService : BaseService<LudothequeService>, ILudothequeService
    {
        /// <summary>
        /// Data Store
        /// </summary>
        private readonly IDataStore _store;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public LudothequeService(
            IStringLocalizer<LudothequeService> localizer,
            IMapper mapper,
            IDataStore store) : base(localizer, mapper)
        {
            _store = store;
        }

        #region Méthodes publiques

        /// <summary>
        /// Retourne les items de la ludothèque du type donné
        /// </summary>
        /// <returns>Les items de la ludothèque du type donnée</returns>
        public IEnumerable<ItemDto> GetByType(string type)
        {
            switch (type)
            {
                case "Jeu vidéo":
                    return _store.Jeux;
                case "Film/Série":
                    return _store.FilmsSeries;
                case "Anime":
                    return _store.Animes;
                default:
                    return new List<ItemDto>();
            }
        }

        #endregion
    }
}
