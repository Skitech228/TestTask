using System;
using System.Collections.Generic;

namespace Domain.Core.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetPhotoList();

        Photo GetPhoto(int id);

        void Create(Photo item);

        void Update(Photo item);

        void Delete(int id);

        void Save();
    }
}
