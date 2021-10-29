#region Using derectives

using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Shared
{
    public interface ITextRepository
    {
        Task<List<Text>> GetTextList();

        Task<Text> GetText(int id);

        Task Create(Text item);

        Task Update(Text item);

        Task Delete(int id);

        Task Save();

        Task<bool> IsExists(int id);
    }
}