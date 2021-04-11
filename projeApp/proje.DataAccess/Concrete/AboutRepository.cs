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
    public class AboutRepository : EFBaseRepository<ProjeDbContext,About>, IAboutRepository
    {
        //public AboutRepository(ProjeDbContext context) : base(context)
        //{

            //public async Task<List<About>> Active()
            //{
            //    using (var aboutDbContext = new ProjeDbContext())
            //    {
            //        return await aboutDbContext.Abouts.Where(x => x.isActive).ToListAsync();
            //    }
            //}

            //public async Task<About> Active(int id, bool active)
            //{
            //    using (var aboutDbContext = new ProjeDbContext())
            //    {
            //        var aktifAbout = await GetAboutById(id);
            //        if (active == true)
            //        {
            //            aktifAbout.isActive = true;
            //            aktifAbout.isDelete = false;
            //        }
            //        else
            //        {
            //            aktifAbout.isActive = false;
            //        }
            //        aboutDbContext.Abouts.Update(aktifAbout);
            //        await aboutDbContext.SaveChangesAsync();
            //        return aktifAbout;
            //    }
            //}
        //}
        //public async Task<About> CreateAbout(About about)
        //{
        //    using (var aboutDbContext = new ProjeDbContext())
        //    {
        //        var kayıtlıAbout = await aboutDbContext.Abouts.FirstOrDefaultAsync(
        //            x => x.mediaUrl==about.mediaUrl&&
        //            x.Text==about.Text&&
        //            x.Title==about.Title
        //            );
        //        if (kayıtlıAbout != null)
        //        {
        //            kayıtlıAbout.isActive = true;
        //            kayıtlıAbout.isDelete = false;
        //            aboutDbContext.Abouts.Update(kayıtlıAbout);
        //            await aboutDbContext.SaveChangesAsync();
        //            return kayıtlıAbout;
        //        }
        //        else
        //        {
        //            about.isActive = true;
        //            aboutDbContext.Abouts.Add(about);
        //            await aboutDbContext.SaveChangesAsync();
        //            return about;
        //        }
        //    }
        //}
               
        //public async Task DeleteAbout(int id)
        //{
        //    try
        //    {
        //        using (var aboutDbContext = new ProjeDbContext())
        //        {
        //            var deleteAbout = await GetAboutById(id);
        //            deleteAbout.isDelete = true;
        //            deleteAbout.isActive = false;
        //            aboutDbContext.Abouts.Update(deleteAbout);

        //            aboutDbContext.EnsureAutoHistory();
        //            await aboutDbContext.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        var test = e.Message; ;
        //        throw;
        //    }
        //}

        //public async Task<About> GetAboutById(int id)
        //{
        //    using (var aboutDbContext = new ProjeDbContext())
        //    {
        //        return await aboutDbContext.Abouts.FindAsync(id);
        //    }
        //}

        //public async Task<List<About>> GetAllAbout()
        //{
        //    using (var aboutDbContext = new ProjeDbContext())
        //    {
        //        return await aboutDbContext.Abouts.Where(x => !x.isDelete).ToListAsync();
        //    }
        //}
        
        //public async Task<About> UpdateAbout(About about)
        //{
        //    using (var aboutDbContext = new ProjeDbContext())
        //    {                
        //        aboutDbContext.Abouts.Update(about);                
        //        //aboutDbContext.EnsureAutoHistory();
        //        await aboutDbContext.SaveChangesAsync();
        //        return about;
        //    }
        //}
    }
}
