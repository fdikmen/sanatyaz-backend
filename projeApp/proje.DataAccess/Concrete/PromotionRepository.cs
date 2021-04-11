using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace proje.DataAccess.Concrete
{
    public class PromotionRepository : EFBaseRepository<ProjeDbContext, Promotion>, IPromotionRepository
    {

        //public PromotionRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<List<Promotion>> Active()
        //{
        //    using (var promotionDbContext = new ProjeDbContext())
        //    {
        //        return await promotionDbContext.Promotions.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Promotion> Active(int id, bool active)
        //{
        //    using (var promotionDbContext = new ProjeDbContext())
        //    {
        //        var aktifPromotion = await GetPromotionById(id);
        //        if (active == true)
        //        {
        //            aktifPromotion.isActive = true;
        //            aktifPromotion.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifPromotion.isActive = false;
        //        }
        //        promotionDbContext.Promotions.Update(aktifPromotion);
        //        await promotionDbContext.SaveChangesAsync();
        //        return aktifPromotion;
        //    }
        //}

        //public async Task<Promotion> CreatePromotion(Promotion promotion)
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {
        //        var kayıtlıPromotion=await promotionDbContext.Promotions.FirstOrDefaultAsync(
        //            x => x.promotionText == promotion.promotionText &&
        //            x.promotionBoxSize == promotion.promotionBoxSize&&
        //            x.promotionTitle == promotion.promotionTitle &&
        //            x.mediaUrl == promotion.mediaUrl &&
        //            x.imageUrl == promotion.imageUrl
        //            );
        //        if (kayıtlıPromotion != null)
        //        {
        //            kayıtlıPromotion.isActive = true;
        //            kayıtlıPromotion.isDelete = false;
        //            promotionDbContext.Promotions.Update(kayıtlıPromotion);
        //            await promotionDbContext.SaveChangesAsync();
        //            return kayıtlıPromotion;
        //        }
        //        else
        //        {
        //            promotion.isActive = true;
        //            promotionDbContext.Promotions.Add(promotion);
        //            await promotionDbContext.SaveChangesAsync();
        //            return promotion;
        //        }
        //    } 
        //}

        //public async Task DeletePromotion(int id)
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {
        //        var deletePromotion=await GetPromotionById(id);
        //        deletePromotion.isDelete = true;
        //        deletePromotion.isActive = false;
        //        promotionDbContext.Promotions.Update(deletePromotion);
        //        //promotionDbContext.Promotions.Remove(deletePromotion);
        //        await promotionDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Promotion>> GetAllPromotion()
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {
        //        return await promotionDbContext.Promotions.Where(x => !x.isDelete).ToListAsync();               
        //    }
        //}

        //public async Task<Promotion> GetPromotionById(int id)
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {
        //        return await promotionDbContext.Promotions.FindAsync(id);
        //    }
        //}

        //public async Task<Promotion> GetPromotionBySize(string boxSize)
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {
        //        //var kayıt= promotionDbContext.Promotions.Where(x => x.promotionBoxSize == boxSize);
        //        //return kayıt;
        //        return await promotionDbContext.Promotions.FirstOrDefaultAsync(x => x.promotionBoxSize == boxSize);
        //    }
        //}

        //public async Task<Promotion> UpdatePromotion(Promotion promotion)
        //{
        //    using(var promotionDbContext=new ProjeDbContext())
        //    {                
        //        promotionDbContext.Promotions.Update(promotion);
        //        await promotionDbContext.SaveChangesAsync();
        //        return promotion;
        //    }
        //}
    }
}
