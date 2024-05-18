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
        /// Est-ce que le jeu est terminé ?
        /// </summary>
        /// <remarks>Valorisé uniquement pour les items de Type = "Jeu vidéo"</remarks>
        public bool IsTermine { get; set; }

        /// <summary>
        /// Relation table de jointure
        /// </summary>
        public List<Tag> Tags { get; set; } = new();

        /// <summary>
        /// Recopie les champs d'une entité à une autre
        /// </summary>
        /// <param name="item">l'entité possédant les nouvelles valeurs à copier</param>
        public void Copy(Item item)
        {
            Nom = item.Nom;
            Type = item.Type;
            Plateforme = item.Plateforme;
            Tags = item.Tags;
            IsTermine = item.IsTermine;
        }
    }
}
