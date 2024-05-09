namespace Ludotek.Repositories.Models
{
    /// <summary>
    /// Model de la table Tag
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom tag
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Relation table de jointure
        /// </summary>
        public List<Item> Items { get; set; } = new();
    }
}
