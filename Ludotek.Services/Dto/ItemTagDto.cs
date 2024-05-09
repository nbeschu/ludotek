namespace Ludotek.Services.Dto
{
    public partial class ItemTagDto
    {
        /// <summary>
        /// Id item
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Id tag
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Foreign keys
        /// </summary>
        public ItemDto Item { get; set; }
        public TagDto Tag { get; set; }
    }
}
