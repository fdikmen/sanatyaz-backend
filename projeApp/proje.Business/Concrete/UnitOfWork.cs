using Microsoft.EntityFrameworkCore;
using proje.Business.Abstract;
using proje.Core.Concrete;
using proje.DataAccess;
using proje.DataAccess.Concrete;
using System;

namespace proje.Business.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
    //    protected ProjeDbContext context;
    //    public UnitOfWork(ProjeDbContext _context)
    //    {
    //        context = _context;
    //    }

    //    IAboutService about;
    //    IAdminService admin;
    //    IBlogService blog;
    //    ICategoryService category;
    //    ICommentService comment;
    //    IConstantService constant;
    //    IFormService form;
    //    IMenuService menu;
    //    IPopupService popup;
    //    IPromotionService promotion;
    //    ISliderService slider;
    //    IUserService user;

    //    public IAboutService About => about ?? (about = new AboutManager(new AboutRepository(context)));

    //    public IAdminService Admin => admin ?? (admin = new AdminManager(new AdminRepository(context)));

    //    public ICategoryService Category => category ?? (category = new CategoryManager(new CategoryRepository(context)));

    //    public IBlogService Blog => blog ?? (blog = new BlogManager(new BlogRepository(context)));

    //    public ICommentService Comment => comment ?? (comment = new CommentManager(new CommentRepository(context)));

    //    public IConstantService Constant => constant ?? (constant = new ConstantManager(new ConstantRepository(context)));

    //    public IFormService Form => form ?? (form = new FormManager(new FormRepository(context)));

    //    public IMenuService Menu => menu ?? (menu = new MenuManager(new MenuRepository(context)));

    //    public IPopupService Popup => popup ?? (popup = new PopupManager(new PopupRepository(context)));

    //    public IPromotionService Promotion => promotion ?? (promotion = new PromotionManager(new PromotionRepository(context)));

    //    public ISliderService Slider => slider ?? (slider = new SliderManager(new SliderRepository(context)));

    //    public IUserService User => user ?? (user = new UserManager(new UserRepository(context)));

        //public ResultMessage<int> SaveChanges()
        //{
        //    context.EnsureAutoHistory();
        //    using (var dbTransaction = context.Database.BeginTransaction())
        //    {
        //        //log kayıtları
        //        //context.EnsureAutoHistory();
        //        try
        //        {
        //            int result = context.SaveChanges();
        //            dbTransaction.Commit();
        //            return new ResultMessage<int> { BasariliMi = true, Mesaj = "İşlem başarılı" };
        //        }
        //        catch (Exception ex)
        //        {
        //            dbTransaction.Rollback();
        //            return new ResultMessage<int> { BasariliMi = false, Mesaj = ex.Message };
        //        }
        //    }

        //}
    }
}
