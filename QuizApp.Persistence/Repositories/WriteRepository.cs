using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Repositories;
using QuizApp.Domain.Common;

namespace QuizApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            var result = await Table.AddAsync(model);
            return result.State == EntityState.Added;
        }

        /// <summary>
        /// Check exceptions later
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            var result = Table.Remove(model);
            return result.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await Table.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                Table.Remove(result);
                return true;
            }
            throw new NotFoundException("Record doesn't exist");

        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            var result = Table.Update(model);
            return result.State == EntityState.Modified;
        }
    }
}
