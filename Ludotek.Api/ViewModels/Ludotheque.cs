using Ludotek.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.ViewModels
{
    public class Ludotheque : GlobalModel
    {
        /// <summary>
        /// Nom item
        /// </summary>
        public string NomItem { get; set; }

        /// <summary>
        /// Liste des tags
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Converteur Dto -> Model
        /// </summary>
        /// <param name="dto">Le Dto à convertir</param>
        /// <returns>Le Model converti</returns>
        public static Ludotheque ToModel(LudothequeDto dto)
        {
            var listTags = dto?.LudoTag.Where(x => x.Ludotheque.NomItem == dto.NomItem)
                .Select(x => x.Tag).ToList();

            return new Ludotheque
            {
                Erreur = Erreur.ToModel(dto.Erreur),
                NomItem = dto.NomItem,
                Tags = listTags.ConvertAll(x => Tag.ToModel(x))
            };
        }

        /// <summary>
        /// Converteur Model -> Dto
        /// </summary>
        /// <returns>Le Dto converti</returns>
        public LudothequeDto ToDto()
        {
            var dto = new LudothequeDto
            {
                NomItem = NomItem
            };

            foreach (var tag in Tags)
            {
                dto.LudoTag.Add(new LudoTagDto
                {
                    Ludotheque = dto,
                    Tag = tag.ToDto()
                });
            }

            return dto;
        }
    }
}
