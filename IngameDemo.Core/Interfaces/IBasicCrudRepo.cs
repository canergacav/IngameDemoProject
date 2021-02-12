using IngameDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.Repository
{
    public interface IBasicCrudRepo<T> where T:EntityBase
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        T Find(int Id);
        IEnumerable<T> FindAll();
    }
}
