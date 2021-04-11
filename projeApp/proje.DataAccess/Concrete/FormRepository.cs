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
    public class FormRepository : EFBaseRepository<ProjeDbContext, Form>, IFormRepository
    {

        public List<Form> GetAllForm()
        {
            using (var context = new ProjeDbContext())
            {
                var form = context.Forms
                    .Include(c => c.FormElements)                    
                    .Where(x => !x.isDelete)
                    .ToList();
                return form;              

            }            
        }


        //public FormRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<List<Form>> Active()
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        return await formDbContext.Forms.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Form> Active(int id, bool active)
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        var aktifForm = await GetFormById(id);
        //        if (active == true)
        //        {
        //            aktifForm.isActive = true;
        //            aktifForm.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifForm.isActive = false;
        //        }
        //        formDbContext.Forms.Update(aktifForm);
        //        await formDbContext.SaveChangesAsync();
        //        return aktifForm;
        //    }
        //}

        //public async Task<Form> CreateForm(Form form)
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        form.isActive = true;
        //        formDbContext.Forms.Add(form);
        //        await formDbContext.SaveChangesAsync();
        //        return form;
        //    }
        //}

        //public async Task DeleteForm(int id)
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        var deleteForm = await GetFormById(id);
        //        deleteForm.isDelete = true;
        //        deleteForm.isActive = false;
        //        formDbContext.Forms.Update(deleteForm);                
        //        await formDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Form>> GetAllForm()
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        return await formDbContext.Forms.Where(x => !x.isDelete).ToListAsync();
        //    }
        //}

        //public async Task<Form> GetFormById(int id)
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {
        //        return await formDbContext.Forms.FindAsync(id);
        //    }
        //}

        //public async Task<Form> UpdateForm(Form form)
        //{
        //    using (var formDbContext = new ProjeDbContext())
        //    {                
        //        formDbContext.Forms.Update(form);
        //        await formDbContext.SaveChangesAsync();
        //        return form;
        //    }
        //}

    }
}
