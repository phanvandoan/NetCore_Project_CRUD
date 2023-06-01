using Microsoft.EntityFrameworkCore;
using NetCore_Project.DTO;
using NetCore_Project.Interfaces;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ExampleDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenericRepository(ExampleDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            //var query = context.Set<T>();
            //return query;
            try
            {
                var query = await context.Set<T>().ToListAsync();
                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<T> Get(long id, bool isActive = true)
        {
            //return entities.FirstOrDefault(s => s.Id == id)!;
            return await context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter)
        {
            return entities.Where(filter);
        }

        public void Insert(T entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            //entity.CreatedAt = DateTime.Now;
            //entity.UpdatedAt = DateTime.Now;

            entities.Add(entity);

            if (saveChange)
                context.SaveChanges();

        }

        public void Update(T entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //entity.UpdatedAt = DateTime.Now;
            if (saveChange)
                context.SaveChanges();
        }

        public void Delete(T entity, bool saveChange = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            if (saveChange)
                context.SaveChanges();
        }
    }

}
