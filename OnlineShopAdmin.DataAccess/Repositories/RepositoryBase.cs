using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShopAdmin.DataAccess.DbContexts;
using OnlineShopAdmin.Domain.Contracts;

namespace OnlineShopAdmin.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AdventureWorksLT2019Context _contex { get; set; }
        public RepositoryBase(AdventureWorksLT2019Context adventureWorksLT2019Context)
        {
            _contex = adventureWorksLT2019Context
                ?? throw new ArgumentNullException(nameof(adventureWorksLT2019Context));
        }
       

        public IQueryable<T> GetAll()
        {
            return _contex.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _contex.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _contex.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _contex.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _contex.Set<T>().Update(entity);
        }

        public T GetById(Guid id)
        {
            return _contex.Set<T>().Find(id);
        }

        public bool Exists(T entity)
        {
            return _contex.Set<T>().Contains(entity);
        }
        
    }
}
