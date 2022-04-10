using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public interface IProjekt<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<ICollection> GetOne(int id);
        Task<T> Add(T newEntity);
        Task<T> Delete(int id);
        Task<T> Update(T Entity);

    }
}
