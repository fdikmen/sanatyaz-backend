using proje.Core.Concrete;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace proje.Business.Abstract
{
    public interface IFormArchiveService
    {
        ResultMessage<FormArchive> Add(FormArchive data);
        ResultMessage<FormArchive> Update(FormArchive data);
        ResultMessage<FormArchive> Delete(int id);
        ResultMessage<FormArchive> SoftDelete(int id);
        ResultMessage<ICollection<FormArchive>> GetAll(Expression<Func<FormArchive, bool>> filter = null);
        ResultMessage<FormArchive> Get(Expression<Func<FormArchive, bool>> filter);
    }
}
