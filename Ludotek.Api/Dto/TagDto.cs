using System;
using System.Collections.Generic;

namespace Ludotek.Api.Dto
{
    public partial class TagDto
    {
        public TagDto()
        {
            LudoTag = new HashSet<LudoTagDto>();
        }

        public int Id { get; set; }
        public string NomTag { get; set; }

        public ICollection<LudoTagDto> LudoTag { get; set; }
    }
}
