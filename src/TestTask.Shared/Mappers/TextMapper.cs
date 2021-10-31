using CsvHelper.Configuration;
using TestTask.Domain.Entity;

namespace TestTask.Shared.Mappers
{
    public class TextMapper : ClassMap<Text>
    {
        public TextMapper()
        {
            Map(x => x.Id).Name("Id");
            Map(x => x.Cost).Name("Cost");
            Map(x => x.CreationDate).Name("CreationDate");
            Map(x => x.PurchasesMadeNumber).Name("PurchasesMadeNumber");
            Map(x => x.Size).Name("Size");
            Map(x => x.Title).Name("Title");
            Map(x => x.Content).Name("Content");
            Map(x => x.AuthorId).Name("AuthorId"); 
        }
    }
}