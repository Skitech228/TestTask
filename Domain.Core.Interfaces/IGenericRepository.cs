using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Domain;

namespace Domain.Core.Interfaces
{
    public interface IGenericRepository: IDisposable
    {

        Photo GetPhoto(int id);

        void Create(Photo item);

        void Update(Photo item);

        void Delete(int id);

        void Save();
    }
}
