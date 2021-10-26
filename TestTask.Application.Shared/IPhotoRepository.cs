using System;
using System.Collections.Generic;
using TestTask.Domain;

namespace TestTask.Application.Shared
{
    public interface IPhotoRepository : IDisposable
    {
        IEnumerable<Photo> GetPhotoList();

        Photo GetPhoto(int id);

        void Create(Photo item);

        void Update(Photo item);

        void Delete(int id);

        void Save();
    }
}
