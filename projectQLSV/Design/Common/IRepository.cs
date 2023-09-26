using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Common
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableUntracked { get; }
        ICollection<T> Local { get; }
        T Attach(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        bool? AutoCommitEnabled { get; set; }
        public IQueryable<T> GetAll();
        public Task CommitAsync();
    }
}
