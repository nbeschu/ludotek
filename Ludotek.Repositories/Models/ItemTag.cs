namespace Ludotek.Repositories.Models
{
    public class ItemTag
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
        public Item Item { get; set; }
        public Tag Tag { get; set; }
    }
}
