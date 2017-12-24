using System;
using System.Collections.Generic;

namespace Ludotek.Api.Dto
{
    public partial class LudoTagDto
    {
        public int LudothequeId { get; set; }
        public int TagId { get; set; }

        public LudothequeDto Ludotheque { get; set; }
        public TagDto Tag { get; set; }
    }
}
