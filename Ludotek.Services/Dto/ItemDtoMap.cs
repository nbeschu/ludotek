using CsvHelper.Configuration;

namespace Ludotek.Services.Dto
{
    public class ItemDtoMap : ClassMap<ItemDto>
    {
        public ItemDtoMap()
        {
            Map(m => m.Nom).Name("Nom");
            Map(m => m.Type).Name("Type");
            Map(m => m.Plateforme).Name("Plateforme");
        }
    }
}
