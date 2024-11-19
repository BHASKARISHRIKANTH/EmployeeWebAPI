using EmployeeWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeWebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();

        }

        public int Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
            return 1;

        }

        

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            var entity = _table.Find(id);
            return entity;


        }


       
    
    }
}
