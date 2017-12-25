using Ludotek.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.ViewModels
{
    public class Tag : GlobalModel
    {
        /// <summary>
        /// Nom du tag
        /// </summary>
        public string NomTag { get; set; }

        /// <summary>
        /// Converteur Dto -> Model
        /// </summary>
        /// <param name="dto">Le Dto à convertir</param>
        /// <returns>Le Model converti</returns>
        public static Tag ToModel (TagDto dto)
        {
            return new Tag
            {
                Erreur = Erreur.ToModel(dto.Erreur),
                NomTag = dto.NomTag
            };
        }

        /// <summary>
        /// Converteur Model -> Dto
        /// </summary>
        /// <returns>Le Dto converti</returns>
        public TagDto ToDto()
        {
            return new TagDto
            {
                NomTag = NomTag
            };
        }
    }
}
