using System;
using System.Collections.Generic;
using Teste_CRUD_CiaTecnica.Application.Interfaces;
using Teste_CRUD_CiaTecnica.Domain.Interfaces.Services;

namespace Teste_CRUD_CiaTecnica.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;
        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }
        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _service.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}
