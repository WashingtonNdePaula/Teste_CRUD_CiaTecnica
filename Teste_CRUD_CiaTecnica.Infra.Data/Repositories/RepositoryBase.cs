using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Repositories;
using Teste_CRUD_CiaTecnica.Infra.Data.Context;

namespace Teste_CRUD_CiaTecnica.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DBContext_Teste_CRUD Db = new DBContext_Teste_CRUD();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
