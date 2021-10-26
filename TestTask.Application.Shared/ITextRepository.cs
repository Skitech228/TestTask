using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Shared
{
    public interface ITextRepository
    {
        IEnumerable<Text> GetTextList();

        Text GetText(int id);

        void Create(Text item);

        void Update(Text item);

        void Delete(int id);

        void Save();
    }
}
