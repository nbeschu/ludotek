using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Dto
{
    public class GlobalDto
    {
        /// <summary>
        /// Gestion des erreurs
        /// </summary>
        [NotMapped]
        public ErreurDto Erreur { get; set; }
    }
}
