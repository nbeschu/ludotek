using System.ComponentModel.DataAnnotations.Schema;

namespace Ludotek.Services.Dto
{
    public class GlobalDto
    {
        /// <summary>
        /// Gestion des erreurs
        /// </summary>
        public ErreurDto Erreur { get; set; }
    }
}
