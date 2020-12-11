using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusKos.Data.Context;
using MusKos.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMusDbContext db;

        public UnitOfWork(IMusDbContext db)
        {
            this.db = db;
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return db.Entry(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
