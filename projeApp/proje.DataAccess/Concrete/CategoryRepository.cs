using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class CategoryRepository : EFBaseRepository<ProjeDbContext,Category>,ICategoryRepository
    {
        //public CategoryRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<List<Category>> Active()
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        return await categoryDbContext.Categorys.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Category> Active(int id, bool active)
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        var aktifCategory = await GetCategoryById(id);
        //        if (active == true)
        //        {
        //            aktifCategory.isActive = true;
        //            aktifCategory.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifCategory.isActive = false;
        //        }
        //        categoryDbContext.Categorys.Update(aktifCategory);
        //        await categoryDbContext.SaveChangesAsync();
        //        return aktifCategory;
        //    }
        //}

        //public async Task<Category> CreateCategory(Category category)
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        var kayıtlıCategory = await categoryDbContext.Categorys.FirstOrDefaultAsync(
        //            x => x.MediaUrl==category.MediaUrl &&
        //            x.CategoryUrl==category.CategoryUrl &&
        //            x.CategoryText==category.CategoryText&&
        //            x.CategoryName==category.CategoryName                    
        //            );
        //        if (kayıtlıCategory != null)
        //        {
        //            kayıtlıCategory.isActive = true;
        //            kayıtlıCategory.isDelete = false;
        //            categoryDbContext.Categorys.Update(kayıtlıCategory);
        //            await categoryDbContext.SaveChangesAsync();
        //            return kayıtlıCategory;
        //        }
        //        else
        //        {
        //            category.isActive = true;
        //            categoryDbContext.Categorys.Add(category);
        //            await categoryDbContext.SaveChangesAsync();
        //            return category;
        //        }
        //    }
        //}       

        //public async Task DeleteCategory(int id)
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        var deleteCategory = await GetCategoryById(id);
        //        deleteCategory.isDelete = true;
        //        deleteCategory.isActive = false;
        //        categoryDbContext.Categorys.Update(deleteCategory);                
        //        await categoryDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Category>> GetAllCategory()
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        return await categoryDbContext.Categorys.Where(x => !x.isDelete).ToListAsync();
                
        //    }
        //}

        //public async Task<Category> GetCategoryById(int id)
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {
        //        return await categoryDbContext.Categorys.FindAsync(id);
        //    }
        //}

        //public async Task<Category> UpdateCategory(Category category)
        //{
        //    using (var categoryDbContext = new ProjeDbContext())
        //    {                
        //        categoryDbContext.Categorys.Update(category);
        //        await categoryDbContext.SaveChangesAsync();
        //        return category;
        //    }
        //}

        
    }
}
