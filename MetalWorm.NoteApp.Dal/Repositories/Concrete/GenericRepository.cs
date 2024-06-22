using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.Dal.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new AppDbContext();
            _dbSet = _context.Set<T>();
        }

        public GenericRepository(AppDbContext appDbContext) 
        { 
            _context = appDbContext;
            _dbSet = _context.Set<T>();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Böyle bir kullanıcı yok");
            }
            else
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                var Insertedentity = await _dbSet.AddAsync(entity);
                Console.WriteLine($"Repo Katmanı eklenen entity durumu={Insertedentity.State}");
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ekleme işlemi sırasında hata oluştu: {ex}");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                var updatedEntity= _dbSet.Update(entity);
                if (updatedEntity.State == EntityState.Modified)
                {
                    Console.WriteLine($"entity repositoryde güncellendi");
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Güncelleme esnasında Repository'de hata oluştu: {ex}");
            }
            
        }
    }
}
