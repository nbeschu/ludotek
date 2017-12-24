using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ludotek.Api.Dto
{
    public partial class LudothequeDto : GlobalDto
    {
        public LudothequeDto()
        {
            LudoTag = new HashSet<LudoTagDto>();
        }

        public int Id { get; set; }
        public string NomItem { get; set; }

        public ICollection<LudoTagDto> LudoTag { get; set; }

        [NotMapped]
        public ErreurDto Erreur { get; set; }
    }
}
