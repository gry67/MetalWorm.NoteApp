using MetalWorm.NoteApp.BL.Abstract;
using MetalWorm.NoteApp.Dal;
using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using MetalWorm.NoteApp.Dal.Repositories.Concrete;
using MetalWorm.NoteApp.Dal.UnitOfWork;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Concrete
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        private IGenericRepository<T> _repository = new GenericRepository<T>();
        private IUOW _unitOfWork = new UOW();
        private readonly AppDbContext _context;

        public GenericManager()
        {
            _context = new AppDbContext();
        }


        public async Task DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
            //await _unitOfWork.SaveAsync();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = _repository.GetAllAsync();
            return entities;
        }

        public Task<T> GetByIdAsync(int id)
        {
            var entity = _repository.GetByIdAsync(id);
            return entity;
        }

        public async Task InsertAsync(T entity)
        {
            _repository.InsertAsync(entity);
            //await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.UpdateAsync(entity);
            //await _unitOfWork.SaveAsync();
        }
    }
}
