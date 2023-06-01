using Microsoft.EntityFrameworkCore;
using Nest;
using NetCore_Project.DTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ExampleDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ExampleDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public int CountAll()
        {
            return entities.Count();
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = entities;

            if (Filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public T Get(int id, bool isActive = true)
        {
            return entities.FirstOrDefault(s => s.Id == id && (s.Used || !isActive));
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

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

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
            entity.UpdatedAt = DateTime.Now;
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
