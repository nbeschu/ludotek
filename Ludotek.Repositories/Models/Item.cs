namespace Ludotek.Repositories.Models
{
    /// <summary>
    /// Dto Généré via reverse engineering de la DBB
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

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
        /// Relation table de jointure
        /// </summary>
        public List<Tag> Tags { get; set; } = new();
    }
}
