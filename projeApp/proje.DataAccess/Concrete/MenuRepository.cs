using Microsoft.EntityFrameworkCore;
using proje.Core.Abstract;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class MenuRepository : EFBaseRepository<ProjeDbContext, Menu>, IMenuRepository
    {
        public List<Menu> GetAllMenu()
        {
            using (var context = new ProjeDbContext())
            {
                var menu = context.Menus
                    .Include(c => c.CreatePages)
                    .Where(x => !x.isDelete)
                    .ToList();
                return menu;
            }
        }
        //public MenuRepository(ProjeDbContext context) : base(context)
        //{

        //}



        //public async Task<List<Menu>> Active()
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        return await menuDbContext.Menus.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Menu> Active(int id,bool active)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        var aktifMenu = await GetMenuById(id);
        //        if (active == true)
        //        {
        //            aktifMenu.isActive = true;
        //            aktifMenu.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifMenu.isActive = false;
        //        }                
        //        menuDbContext.Menus.Update(aktifMenu);
        //        await menuDbContext.SaveChangesAsync();
        //        return aktifMenu;                
        //    }
        //}

        //public async Task<Menu> CreateMenu(Menu menu)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        var kayıtlıMenu=await menuDbContext.Menus.FirstOrDefaultAsync(
        //            x=>x.menuName==menu.menuName && 
        //            x.imageUrl==menu.imageUrl &&
        //            x.iconClass==menu.iconClass
        //            );
        //        if (kayıtlıMenu != null)
        //        {
        //            kayıtlıMenu.isActive = true;
        //            kayıtlıMenu.isDelete = false;
        //            menuDbContext.Menus.Update(kayıtlıMenu);
        //            await menuDbContext.SaveChangesAsync();
        //            return kayıtlıMenu;
        //        }
        //        else
        //        {
        //            menu.isActive = true;
        //            menuDbContext.Menus.Add(menu);
        //            await menuDbContext.SaveChangesAsync();
        //            return menu;
        //        }                
        //    }
        //}

        //public async Task DeleteMenu(int id)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        var deleteMenu =await GetMenuById(id);
        //        deleteMenu.isDelete = true;
        //        deleteMenu.isActive = false;
        //        menuDbContext.Menus.Update(deleteMenu);
        //        //menuDbContext.Menus.Remove(deleteMenu);
        //        await menuDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Menu>> GetAllMenu()
        //{
        //    using (var menuDbContext = new ProjeDbContext())
        //    {
        //        return await menuDbContext.Menus.Where(x => !x.isDelete).ToListAsync();                  
        //    }
        //}

        //public async Task<ICollection<Menu>> GetMainMenu()
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        return await menuDbContext.Menus.Where(x => x.mainMenuId == null || x.mainMenuId == 0).ToListAsync();
        //    }
        //}

        //public async Task<Menu> GetMenuById(int id)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        return await menuDbContext.Menus.FindAsync(id);
        //    }
        //}

        //public async Task<Menu> GetMenuByName(string name)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {
        //        return await menuDbContext.Menus.FirstOrDefaultAsync(x=>x.menuName.ToLower()==name.ToLower());
        //    }
        //}

        //public async Task<Menu> UpdateMenu(Menu menu)
        //{
        //    using(var menuDbContext=new ProjeDbContext())
        //    {                
        //        menuDbContext.Menus.Update(menu);
        //        await menuDbContext.SaveChangesAsync();
        //        return menu;
        //    }
        //}
    }
}
