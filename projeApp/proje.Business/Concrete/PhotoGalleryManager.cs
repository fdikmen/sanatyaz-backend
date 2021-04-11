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
    public class PhotoGalleryManager : IPhotoGalleryService
    {
        private IPhotoGalleryRepository repository;
        public PhotoGalleryManager(IPhotoGalleryRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<PhotoGallery> Add(PhotoGallery data)
        {
            return repository.Add(data);
        }

        public ResultMessage<PhotoGallery> Delete(int id)
        {
            return repository.Delete(id);
        }

        public ResultMessage<PhotoGallery> Get(Expression<Func<PhotoGallery, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<ICollection<PhotoGallery>> GetAll(Expression<Func<PhotoGallery, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<PhotoGallery> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<PhotoGallery> Update(PhotoGallery data)
        {
            return repository.Update(data);
        }
    }
}
