#region Using derectives

using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Shared.IEntityRepositories
{
    public interface ITextRepository
    {
        Task DisposeAsync();

        Task<List<Text>> GetTextListAsync();

        Task<Text> GetTextAsync(int id);

        Task CreateAsync(Text item);

        Task UpdateAsync(Text item);

        Task DeleteAsync(int id);

        Task SaveAsync();

        Task<bool> IsExists(Text item);
    }
}