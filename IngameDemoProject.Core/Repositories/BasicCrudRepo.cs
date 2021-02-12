using IngameDemoProject.Core.Models;
using IngameDemoProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemoProject.Core.Repositories
{
    public class BasicCrudRepo<T> : IBasicCrudRepo<T> where T : EntityBase
    {
        private readonly ApiContext _appContext
        public BasicCrudRepo()
        {

        }
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
