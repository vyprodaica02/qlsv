using Design.Common;
using Design.Entity;
using Infrastructure.DataEx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MonHocServices<T> : IRepository<T> where T : MonHoc
    {
        private DbSet<T> _services;
        private readonly AppDbContext dbContext;
        public MonHocServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> Table
        {
            get
            {
                return _services;
            }
        }

        public IQueryable<T> TableUntracked
        {
            get
            {
                return _services.AsNoTracking();
            }
        }

        public ICollection<T> Local
        {
            get
            {
                return _services.Local;
            }
        }

        public bool? AutoCommitEnabled { get; set; }


        public async Task AddAsync(T entity)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (Entities.Any(x => x.Id == entity.Id))
                    {
                        throw new InvalidOperationException("Môn học đã tồn tại");
                    }
                    await Entities.AddAsync(entity);
                    if (AutoCommitEnabledInternal)
                    {
                        await CommitAsync();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public T Attach(T entity)
        {
            return _services.Attach(entity).Entity;
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var monHocHt = dbContext.monHocs.FirstOrDefault(x => x.Id == id);

            if (AutoCommitEnabledInternal)
            {
                dbContext.Remove(monHocHt);
                await CommitAsync();
            }
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();

        }

        public async Task UpdateAsync(T entity)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    ChangeStateToModifiedIfApplicable(entity);

                    if (AutoCommitEnabledInternal)
                    {
                        await CommitAsync();

                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        private bool AutoCommitEnabledInternal
        {
            get
            {
                return AutoCommitEnabled ?? true;
            }
        }

        private void ChangeStateToModifiedIfApplicable(T entity)
        {

            var entry = dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
        }
        private DbSet<T> Entities
        {
            get
            {
                if (_services == null)
                {
                    _services = dbContext.Set<T>();
                }

                return _services as DbSet<T>;
            }
        }
    }
}
