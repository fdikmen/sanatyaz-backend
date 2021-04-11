using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using proje.Business.Abstract;
using proje.Business.Concrete;
using proje.DataAccess.Abstract;
using proje.DataAccess.Concrete;
using System.IO;

namespace proje.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IConstantService, ConstantManager>();
            services.AddScoped<IConstantRepository, ConstantRepository>();

            services.AddScoped<IPromotionService, PromotionManager>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutRepository, AboutRepository>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderRepository, SliderRepository>();

            services.AddScoped<IPopupService, PopupManager>();
            services.AddScoped<IPopupRepository, PopupRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IFormElementItemService, FormElementItemManager>();
            services.AddScoped<IFormElementItemRepository, FormElementItemRepository>();

            services.AddScoped<IFormElementService, FormElementManager>();
            services.AddScoped<IFormElementRepository, FormElementRepository>();

            services.AddScoped<IFormService, FormManager>();
            services.AddScoped<IFormRepository, FormRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IPersonelService, PersonelManager>();
            services.AddScoped<IPersonelRepository, PersonelRepository>();

            services.AddScoped<ILikeService, LikeManager>();
            services.AddScoped<ILikeRepository, LikeRepository>();

            services.AddScoped<IPhotoCategoryService, PhotoCategoryManager>();
            services.AddScoped<IPhotoCategoryRepository, PhotoCategoryRepository>();

            services.AddScoped<IPhotoGalleryService, PhotoGalleryManager>();
            services.AddScoped<IPhotoGalleryRepository, PhotoGalleryRepository>();

            services.AddScoped<ICreatePageService, CreatePageManager>();
            services.AddScoped<ICreatePageRepository, CreatePageRepository>();

            services.AddScoped<IStatementService, StatementManager>();
            services.AddScoped<IStatementRepository, StatementRepository>();

            services.AddScoped<IPurposeService, PurposeManager>();
            services.AddScoped<IPurposeRepository, PurposeRepository>();

            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<IMailRepository, MailRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFormArchiveService, FormArchiveManager>();
            services.AddScoped<IFormArchiveRepository, FormArchiveRepository>();

            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactRepository, ContactRepository>();


            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }




            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Menu}/{action=Index}/{id?}");
            });

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images")),
            //    RequestPath="/Images"
            //});
        }
    }
}
