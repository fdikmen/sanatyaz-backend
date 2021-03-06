using Microsoft.EntityFrameworkCore;
using proje.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace proje.Core.Concrete
{
    public class EFBaseRepository<TContext, TEntity> : IRepository<TEntity>
    where TEntity : class, IData, new()
    where TContext : DbContext, new()
    {
        //protected TContext context;
        //public EFBaseRepository(TContext _context)
        //{
        //    context = _context;
        //}
        public ResultMessage<TEntity> Add(TEntity data)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var addedData = context.Entry(data);
                    addedData.State = EntityState.Added;
                    context.EnsureAutoHistory();
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = "Kayıt Eklenemedi." } :
                        new ResultMessage<TEntity> { BasariliMi = true, Data = data, Mesaj = "Kayıt eklenmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }

        public ResultMessage<TEntity> Delete(int id)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var data = context.Set<TEntity>().Find(id);
                    var deletedData = context.Entry(data);
                    deletedData.State = EntityState.Deleted;
                    //data.isDelete = true;                    
                    //deletedData.State = EntityState.Modified;
                    context.EnsureAutoHistory();
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = "Kayıt Silinemedi." } :
                        new ResultMessage<TEntity> { BasariliMi = true, Data = data, Mesaj = "Kayıt silinmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }
        public ResultMessage<TEntity> SoftDelete(int id)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var data = context.Set<TEntity>().Find(id);
                    var deletedData = context.Entry(data);
                    //deletedData.State = EntityState.Deleted;
                    data.isDelete = true;
                    deletedData.State = EntityState.Modified;
                    context.EnsureAutoHistory();
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = "Kayıt Silinemedi." } :
                        new ResultMessage<TEntity> { BasariliMi = true, Data = data, Mesaj = "Kayıt silinmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }

        public ResultMessage<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    TEntity data = context.Set<TEntity>().FirstOrDefault(filter);
                    return data == null ? new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = "Aranan kriterlere uygun kayıt bulunamadı" } :
                        new ResultMessage<TEntity> { BasariliMi = true, Data = data, Mesaj = "Kayıt getirildi." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }

        public ResultMessage<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    ICollection<TEntity> dataList;
                    if (filter == null)
                    {
                        dataList = context.Set<TEntity>().Where(x=>!x.isDelete).ToList();
                    }
                    else
                    {
                        dataList = context.Set<TEntity>().Where(filter).ToList();
                    }
                    return new ResultMessage<ICollection<TEntity>> { BasariliMi = true, Data = dataList, Mesaj = "Veriler listelendi." };

                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<ICollection<TEntity>> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }

        public ResultMessage<TEntity> Update(TEntity data)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var updatedData = context.Entry(data);
                    updatedData.State = EntityState.Modified;
                    context.EnsureAutoHistory();
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = "Kayıt Güncellendi." } :
                        new ResultMessage<TEntity> { BasariliMi = true, Data = data, Mesaj = "Kayıt Güncellenmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { BasariliMi = false, Data = null, Mesaj = ex.Message };
            }
        }
    }
}
