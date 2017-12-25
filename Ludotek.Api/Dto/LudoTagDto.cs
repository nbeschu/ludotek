using System;
using System.Collections.Generic;

namespace Ludotek.Api.Dto
{
    public partial class LudoTagDto
    {
        /// <summary>
        /// Id item
        /// </summary>
        public int LudothequeId { get; set; }

        /// <summary>
        /// Id tag
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Foreign keys
        /// </summary>
        public LudothequeDto Ludotheque { get; set; }
        public TagDto Tag { get; set; }
    }
}
