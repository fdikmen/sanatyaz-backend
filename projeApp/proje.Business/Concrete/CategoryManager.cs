using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace proje.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ResultMessage<Category> Add(Category data)
        {           
            return _categoryRepository.Add(data);
        }

        public ResultMessage<Category> Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public ResultMessage<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryRepository.Get(filter);
        }

        public ResultMessage<ICollection<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryRepository.GetAll(filter);
        }

        public ResultMessage<Category> SoftDelete(int id)
        {
            return _categoryRepository.SoftDelete(id);
        }

        public ResultMessage<Category> Update(Category data)
        {
            return _categoryRepository.Update(data);
        }
    }
}
