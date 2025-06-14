﻿using AutoMapper;
using LudotekV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ludotek2.Controllers
{
    public class GlobalController : Controller
    {
        protected readonly IMapper _mapper;

        /// <summary>
        /// Retourne une réponse OK ou une réponse KO s'il y a une erreur de remontée par le Business
        /// </summary>
        /// <param name="model">Le model résultat du Business</param>
        /// <returns>une réponse OK ou une réponse KO</returns>
        protected IActionResult Result(GlobalModel model)
        {
            if (model.Erreur != null)
            {
                return new ObjectResult(model.Erreur) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

            return Ok(model);
        }

        /// <summary>
        /// Retourne une réponse OK ou une réponse KO s'il y a une erreur de remontée par le Business
        /// </summary>
        /// <param name="models">La demande résultat du Business</param>
        /// <returns>une réponse OK ou une réponse KO</returns>
        protected IActionResult Result(List<GlobalModel> models)
        {
            var avecErreurs = models.FindAll(x => x.Erreur != null);

            if (avecErreurs != null && avecErreurs.Any())
            {
                // Récupération de l'ensemble des erreurs trouvées
                var erreurs = new List<Erreur>();
                foreach (var model in avecErreurs)
                {
                    erreurs.Add(model.Erreur);
                }

                return new ObjectResult(erreurs) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

            return Ok(models);
        }
    }
}
