using System;
using System.Collections.Generic;

namespace Ludotek.Api.Dto
{
    /// <summary>
    /// Dto Généré via reverse engineering de la DBB
    /// </summary>
    public partial class TagDto : GlobalDto
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public TagDto()
        {
            LudoTag = new HashSet<LudoTagDto>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom tag
        /// </summary>
        public string NomTag { get; set; }

        /// <summary>
        /// Relation table de jointure
        /// </summary>
        public ICollection<LudoTagDto> LudoTag { get; set; } = new List<LudoTagDto>();
    }
}
