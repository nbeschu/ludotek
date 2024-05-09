namespace Ludotek.Services.Dto
{
    /// <summary>
    /// Dto Généré via reverse engineering de la DBB
    /// </summary>
    public partial class TagDto : GlobalDto
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
        public List<ItemDto> Items { get; set; } = new();
    }
}
