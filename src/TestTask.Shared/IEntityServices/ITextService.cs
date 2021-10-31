using System.Collections.Generic;
using TestTask.Domain.Entity;

namespace TestTask.Shared.IEntityServices
{
    public interface ITextService
    {
        public void WriteCSVFile(string path, List<Text> text);
    }
}