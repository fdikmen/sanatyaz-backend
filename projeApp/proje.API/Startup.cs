using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using proje.Business.Abstract;
using proje.Business.Concrete;
using proje.DataAccess.Abstract;
using proje.DataAccess.Concrete;
using System.Text;

namespace proje.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IMenuService, MenuManager>();
            services.AddSingleton<IMenuRepository, MenuRepository>();

            services.AddSingleton<ISliderService, SliderManager>();
            services.AddSingleton<ISliderRepository, SliderRepository>();

            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<IPromotionService, PromotionManager>();
            services.AddSingleton<IPromotionRepository, PromotionRepository>();

            services.AddSingleton<IAdminService, AdminManager>();
            services.AddSingleton<IAdminRepository, AdminRepository>();

            services.AddSingleton<IPopupService, PopupManager>();
            services.AddSingleton<IPopupRepository, PopupRepository>();

            services.AddSingleton<IAboutService, AboutManager>();
            services.AddSingleton<IAboutRepository, AboutRepository>();

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IConstantService, ConstantManager>();
            services.AddSingleton<IConstantRepository, ConstantRepository>();

            services.AddSingleton<IFormService, FormManager>();
            services.AddSingleton<IFormRepository, FormRepository>();

            services.AddSingleton<IBlogService, BlogManager>();
            services.AddSingleton<IBlogRepository, BlogRepository>();

            services.AddSingleton<ICommentService, CommentManager>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            
            services.AddSingleton<IFormElementService, FormElementManager>();
            services.AddSingleton<IFormElementRepository, FormElementRepository>();
            
            services.AddSingleton<IPersonelService, PersonelManager>();
            services.AddSingleton<IPersonelRepository, PersonelRepository>();
            
            services.AddSingleton<IPurposeService, PurposeManager>();
            services.AddSingleton<IPurposeRepository, PurposeRepository>();
            
            services.AddSingleton<IStatementService, StatementManager>();
            services.AddSingleton<IStatementRepository, StatementRepository>();
            
            services.AddSingleton<IPhotoCategoryService, PhotoCategoryManager>();
            services.AddSingleton<IPhotoCategoryRepository, PhotoCategoryRepository>();
            
            services.AddSingleton<IPhotoGalleryService, PhotoGalleryManager>();
            services.AddSingleton<IPhotoGalleryRepository, PhotoGalleryRepository>();
           
            services.AddSingleton<ICreatePageService, CreatePageManager>();
            services.AddSingleton<ICreatePageRepository, CreatePageRepository>();
            
            services.AddSingleton<IFormArchiveService, FormArchiveManager>();
            services.AddSingleton<IFormArchiveRepository, FormArchiveRepository>();
           
            services.AddSingleton<IContactService, ContactManager>();
            services.AddSingleton<IContactRepository, ContactRepository>();
           
            
            
            services.AddSingleton<IFormElementItemService, FormElementItemManager>();
            services.AddSingleton<IFormElementItemRepository, FormElementItemRepository>();
            
            

            //services.AddCors(options => options.AddPolicy("AllowOrigin",
            //    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddCors();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerDocument();            

            //JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "service",
                    ValidAudience = "service",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("servicetoflabscom"))
                };
            });

            

            //services.AddDbContext<ProjeDbContext>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<ProjeDbContext>();
            //    context.Database.Migrate();


            //    //migration olmasaydý

            //    //context.Database.EnsureDeleted();
            //    //context.Database.EnsureCreated();
            //}

            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            
            
        }

    }
    
}
