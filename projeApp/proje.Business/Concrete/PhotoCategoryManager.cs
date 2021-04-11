using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Concrete
{
    public class PhotoCategoryManager : IPhotoCategoryService
    {
        private IPhotoCategoryRepository repository;
        public PhotoCategoryManager(IPhotoCategoryRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<PhotoCategory> Add(PhotoCategory data)
        {
            return repository.Add(data);
        }

        public ResultMessage<PhotoCategory> Delete(int id)
        {
            return repository.Delete(id);
        }

        public ResultMessage<PhotoCategory> Get(Expression<Func<PhotoCategory, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<ICollection<PhotoCategory>> GetAll(Expression<Func<PhotoCategory, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<PhotoCategory> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<PhotoCategory> Update(PhotoCategory data)
        {
            return repository.Update(data);
        }
    }
}
