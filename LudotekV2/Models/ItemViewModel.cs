namespace Ludotek2.Models
{
    public class ItemViewModel : GlobalModel
    {
        /// <summary>
        /// Nom item
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Plateforme
        /// </summary>
        public string Plateforme { get; set; }

        /// <summary>
        /// Liste des tags
        /// </summary>
        public List<TagViewModel> Tags { get; set; }
    }
}
