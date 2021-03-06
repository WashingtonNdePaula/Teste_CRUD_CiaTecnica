﻿using System.Collections.Generic;

namespace Teste_CRUD_CiaTecnica.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Dispose();
    }
}
