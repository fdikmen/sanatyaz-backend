using Microsoft.EntityFrameworkCore;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class PopupRepository : EFBaseRepository<ProjeDbContext, Popup>, IPopupRepository
    {
        //public PopupRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<List<Popup>> Active()
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {
        //        return await popupDbContext.Popups.Where(x => x.isActive==true).ToListAsync();
        //    }
        //}

        //public async Task<Popup> Active(int id, bool active)
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {
        //        var aktifPopup =await GetPopupById(id);               
        //        if (active == true)
        //        {
        //            aktifPopup.isActive = true;
        //            aktifPopup.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifPopup.isActive = false;
        //        }
        //        popupDbContext.Popups.Update(aktifPopup);
        //        await popupDbContext.SaveChangesAsync();
        //        return aktifPopup;
        //    }
        //}

        //public async Task<Popup> CreatePopup(Popup popup)
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {
        //        var kayıtlıPopup = await popupDbContext.Popups.FirstOrDefaultAsync(
        //            x => x.pageName == popup.pageName                    
        //            );
        //        if (kayıtlıPopup != null)
        //        {
        //            kayıtlıPopup.isActive = true;
        //            kayıtlıPopup.isDelete = false;
        //            popupDbContext.Popups.Update(kayıtlıPopup);
        //            await popupDbContext.SaveChangesAsync();
        //            return kayıtlıPopup;
        //        }
        //        else
        //        {
        //            popup.isActive = true;
        //            popupDbContext.Popups.Add(popup);
        //            await popupDbContext.SaveChangesAsync();
        //            return popup;
        //        }
        //    }  
        //}

        //public async Task<List<Popup>> GetAllPopup()
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {
        //        return await popupDbContext.Popups.Where(x=>!x.isDelete).ToListAsync();
        //    }
        //}

        //public async Task<Popup> GetPopupById(int id)
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {
        //        return await popupDbContext.Popups.FindAsync(id);
        //    }
        //}

        //public async Task<Popup> UpdatePopup(Popup popup)
        //{
        //    using(var popupDbContext=new ProjeDbContext())
        //    {                
        //        popupDbContext.Update(popup);
        //        await popupDbContext.SaveChangesAsync();
        //        return popup;
        //    }
        //}
        
    }
}
