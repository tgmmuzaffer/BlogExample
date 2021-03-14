using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Repository.Abstract
{
   public interface IBaseRepo<T> where T : class
    {
        Task<T> GetbyId(string url, int Id);
        Task<IList<T>> GetAll(string url);
        Task<bool> Create(string url, T entity);
        Task<bool> Update(string url, T entity);
        Task<bool> Delete(string url, int Id);
    }
}
