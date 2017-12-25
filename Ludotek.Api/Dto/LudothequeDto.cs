using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ludotek.Api.Dto
{
    /// <summary>
    /// Dto Généré via reverse engineering de la DBB
    /// </summary>
    public partial class LudothequeDto : GlobalDto
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public LudothequeDto()
        {
            LudoTag = new HashSet<LudoTagDto>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom item
        /// </summary>
        public string NomItem { get; set; }

        /// <summary>
        /// Relation table de jointure
        /// </summary>
        public ICollection<LudoTagDto> LudoTag { get; set; } = new List<LudoTagDto>();
    }
}
