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
            Map(m => m.IsTermine).Name("IsTermine")
                .TypeConverterOption.BooleanValues(true, true, "true", "1", "y")
                .TypeConverterOption.BooleanValues(false, true, "false", "0", "n", null, string.Empty);
        }
    }
}
