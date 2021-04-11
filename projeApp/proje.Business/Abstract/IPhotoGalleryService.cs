using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IPhotoGalleryService
    {
        ResultMessage<PhotoGallery> Add(PhotoGallery data);
        ResultMessage<PhotoGallery> Update(PhotoGallery data);
        ResultMessage<PhotoGallery> Delete(int id);
        ResultMessage<PhotoGallery> SoftDelete(int id);
        ResultMessage<ICollection<PhotoGallery>> GetAll(Expression<Func<PhotoGallery, bool>> filter = null);
        ResultMessage<PhotoGallery> Get(Expression<Func<PhotoGallery, bool>> filter);
    }
}
