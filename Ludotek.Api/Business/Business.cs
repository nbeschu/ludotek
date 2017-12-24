using Ludotek.Api.Dto;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Business
{
    public class Business<T> where T : class
    {
        /// <summary>
        /// Localisation des messages
        /// </summary>
        private readonly IStringLocalizer<T> localizer;

        /// <summary>
        /// Constructeur avec injection de dépendances
        /// </summary>
        /// <param name="localizer"></param>
        public Business(IStringLocalizer<T> localizer)
        {
            this.localizer = localizer;
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
                Libelle = string.Format(localizer[code], message)
            };

            return erreur;
        }
    }
}
