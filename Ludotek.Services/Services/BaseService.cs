using AutoMapper;
using Ludotek.Services.Dto;
using Microsoft.Extensions.Localization;

namespace Ludotek.Services.Services
{
    public class BaseService<T> where T : class
    {
        /// <summary>
        /// Localisation des messages
        /// </summary>
        private readonly IStringLocalizer<T> _localizer;

        /// <summary>
        /// Le mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Constructeur avec injection de dépendances
        /// </summary>
        /// <param name="localizer"></param>
        public BaseService(IStringLocalizer<T> localizer, IMapper mapper)
        {
            _localizer = localizer;
            _mapper = mapper;
        }

        /// <summary>
        /// Crée un ErreurDto
        /// </summary>
        /// <param name="code">le code erreur</param>
        /// <param name="message">le message à formater avec le message d'erreur</param>
        /// <returns>un objet ErreurDto</returns>
        protected ErreurDto CreateErreur(string code, params string[] message)
        {
            var erreur = new ErreurDto
            {
                Code = code,
                Libelle = string.Format(_localizer[code], message)
            };

            return erreur;
        }
    }
}
