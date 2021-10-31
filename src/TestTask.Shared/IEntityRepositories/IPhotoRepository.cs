#region Using derectives

using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Shared.IEntityRepositories
{
    public interface IPhotoRepository
    {
        Task DisposeAsync();

        Task<List<Photo>> GetPhotoListAsync();

        Task<Photo> GetPhotoAsync(int id);

        Task CreateAsync(Photo item);

        Task UpdateAsync(Photo item);

        Task DeleteAsync(int id);

        Task SaveAsync();

        Task<bool> IsExists(Photo item);
    }
}