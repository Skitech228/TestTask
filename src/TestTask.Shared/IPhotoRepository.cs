#region Using derectives

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Shared
{
    public interface IPhotoRepository : IDisposable
    {
        Task<List<Photo>> GetPhotoList();

        Task<Photo> GetPhoto(int id);

        Task Create(Photo item);

        Task Update(Photo item);

        Task Delete(int id);

        Task Save();

        Task<bool> IsExists(int id);
    }
}