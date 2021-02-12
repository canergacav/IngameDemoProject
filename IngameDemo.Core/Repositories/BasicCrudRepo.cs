using IngameDemo.Core.Context;
using IngameDemo.Core.Models;
using IngameDemo.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemo.Core.Repositories
{
    public class BasicCrudRepo<T> : IBasicCrudRepo<T> where T : EntityBase
    {
        private readonly ApiContext _context;
        private readonly DbSet<T> _dbset;
        public BasicCrudRepo(ApiContext context)
        {
            _context= context;
            _dbset = context.Set<T>();
        }
        public T Create(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            _dbset.Remove(entity);
            return _context.SaveChanges()>1;

        }

        public bool Delete(int id)
        {
            var entity = Find(id);
            return Delete(entity);
        }

        public T Find(int Id)
        {
            return _dbset.Find(Id);
        }

        public IEnumerable<T> FindAll()
        {
            return _dbset;
        }

        public T Update(T entity)
        {
            _dbset.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
