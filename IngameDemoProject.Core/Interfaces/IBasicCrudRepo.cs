using IngameDemoProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemoProject.Core.Repository
{
    public interface IBasicCrudRepo<T> where T:EntityBase
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Find(int Id);
        IEnumerable<T> FindAll();
    }
}
