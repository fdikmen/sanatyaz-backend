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
    public class SliderRepository : EFBaseRepository<ProjeDbContext, Slider>, ISliderRepository
    {
        //public SliderRepository(ProjeDbContext context) : base(context)
        //{

        //}

        //public async Task<List<Slider>> Active()
        //{
        //    using (var sliderDbContext = new ProjeDbContext())
        //    {
        //        return await sliderDbContext.Sliders.Where(x => x.isActive).ToListAsync();
        //    }
        //}

        //public async Task<Slider> Active(int id, bool active)
        //{
        //    using (var sliderDbContext = new ProjeDbContext())
        //    {
        //        var aktifSlider = await GetSliderById(id);
        //        if (active == true)
        //        {
        //            aktifSlider.isActive = true;
        //            aktifSlider.isDelete = false;
        //        }
        //        else
        //        {
        //            aktifSlider.isActive = false;
        //        }
        //        sliderDbContext.Sliders.Update(aktifSlider);
        //        await sliderDbContext.SaveChangesAsync();
        //        return aktifSlider;
        //    }
        //}

        //public async Task<Slider> CreateSlider(Slider slider)
        //{
        //    using (var sliderDbContext = new ProjeDbContext())
        //    {
        //        var kayıtlıSlider = await sliderDbContext.Sliders.FirstOrDefaultAsync(
        //            x => x.imageUrl == slider.imageUrl &&
        //            x.mediaUrl==slider.mediaUrl &&
        //            x.sliderText==slider.sliderText &&
        //            x.sliderUrl==slider.sliderUrl
        //            );
        //        if(kayıtlıSlider != null)
        //        {
        //            kayıtlıSlider.isActive = true;
        //            kayıtlıSlider.isDelete = false;
        //            sliderDbContext.Sliders.Update(kayıtlıSlider);
        //            await sliderDbContext.SaveChangesAsync();
        //            return kayıtlıSlider;
        //        }
        //        else
        //        {
        //            slider.isActive = true;
        //            sliderDbContext.Sliders.Add(slider);
        //            await sliderDbContext.SaveChangesAsync();
        //            return slider;
        //        }
                
        //    }
        //}

        //public async Task DeleteSlider(int id)
        //{
        //    using(var sliderDbContext=new ProjeDbContext())
        //    {
        //        var deleteSlider =await GetSliderById(id);
        //        deleteSlider.isDelete = true;
        //        deleteSlider.isActive = false;
        //        sliderDbContext.Sliders.Update(deleteSlider);
        //        sliderDbContext.Sliders.Remove(deleteSlider);                
        //        await sliderDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Slider>> GetAllSlider()
        //{
        //    using(var sliderDbContext=new ProjeDbContext())
        //    {
        //        return await sliderDbContext.Sliders.Where(x => !x.isDelete).ToListAsync();
        //    }
        //}

        //public async Task<Slider> GetSliderById(int id)
        //{
        //    using(var sliderDbContext=new ProjeDbContext())
        //    {
        //        return await sliderDbContext.Sliders.FindAsync(id);
        //    }
        //}

        //public async Task<Slider> UpdateSlider(Slider slider)
        //{
        //    using(var sliderDbContext=new ProjeDbContext())
        //    {                
        //        sliderDbContext.Sliders.Update(slider);
        //        await sliderDbContext.SaveChangesAsync();
        //        return slider;
        //    }
        //}
    }
}
