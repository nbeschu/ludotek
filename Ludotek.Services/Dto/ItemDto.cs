namespace Ludotek.Services.Dto
{
    /// <summary>
    /// Dto Généré via reverse engineering de la DBB
    /// </summary>
    public partial class ItemDto : GlobalDto
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
        /// Est-ce que le jeu est terminé ?
        /// </summary>
        /// <remarks>Valorisé uniquement pour les items de Type = "Jeu vidéo"</remarks>
        public bool IsTermine { get; set; }

        /// <summary>
        /// Relation table de jointure
        /// </summary>
        public List<TagDto> Tags { get; set; } = new();
    }
}
