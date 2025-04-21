namespace Ludotek.Services.Dto
{
    public class WheelDto : GlobalDto
    { 
        /// <summary>
        /// Nom de la roue
        /// </summary>
        public string NomRoue { get; set; }

        /// <summary>
        /// Les entrées dans la roue
        /// </summary>
        public List<EntryDto> Entries { get; set; } = new();
    }

    public class EntryDto
    {
        /// <summary>
        /// Nom de l'entrée
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// le nombre d'occurence de l'entrée dans la roue
        /// </summary>
        public int NombreOccurence { get; set; }
    }
}
