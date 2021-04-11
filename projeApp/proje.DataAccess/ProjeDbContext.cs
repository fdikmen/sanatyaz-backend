using Microsoft.EntityFrameworkCore;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace proje.DataAccess
{
    public class ProjeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=5.2.81.126; Database=toflabsc_service; uid=tofla_service; pwd=z69ks&4V;");                       

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categorys { get; set; }       
        public DbSet<Constant> Constants { get; set; }       
        public DbSet<Popup> Popups { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormElement> FormElements { get; set; }
        public virtual DbSet<FormElementItem> FormElementItems { get; set; }
        
        public virtual DbSet<FormArchive> FormArchives { get; set; }
        //public virtual DbSet<FormUser> FormUsers { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }        
        public virtual DbSet<Like> Likes { get; set; }        
        
        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<PhotoCategory> PhotoCategories { get; set; }
        public virtual DbSet<PhotoGallery> PhotoGalleries { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<CreatePage> CreatePages { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //log kayıtları
            base.OnModelCreating(modelBuilder.EnableAutoHistory(null));
            
            // configures one-to-many relationship  --> Blog-Comment
            modelBuilder.Entity<Comment>()
                .HasOne(s => s.Blog)
                .WithMany(g => g.Comments)
                .IsRequired();
           
            modelBuilder.Entity<Like>()
                .HasOne(x => x.Comment)
                .WithMany(y => y.Likes)
                .IsRequired();

            // configures one-to-many relationship  --> Form-FormElement
            modelBuilder.Entity<FormElement>()
                .HasOne(s => s.Form)
                .WithMany(g => g.FormElements)
                .IsRequired();

            modelBuilder.Entity<FormElementItem>()
                .HasOne(s => s.FormElement)
                .WithMany(g => g.FormElementItems)
                .IsRequired();

            // configures one-to-many relationship  --> PhotoCategory-PhotoGallery
            modelBuilder.Entity<PhotoGallery>()
                .HasOne(s => s.PhotoCategory)
                .WithMany(g => g.PhotoGalleries)
                .IsRequired();
            // configures one-to-many relationship  --> CreatePage-Menu
            modelBuilder.Entity<CreatePage>()
                .HasOne(s => s.Menu)
                .WithMany(g => g.CreatePages)
                .IsRequired();
            // configures one-to-many relationship  --> FormElement-FormArchive
            modelBuilder.Entity<FormArchive>()
                .HasOne(s => s.FormElement)
                .WithMany(g => g.FormArchives)
                .IsRequired();
            // configures one-to-many relationship  --> FormUser-FormArchive
            //modelBuilder.Entity<FormArchive>()
            //    .HasOne(s => s.FormUser)
            //    .WithMany(g => g.FormArchives)
            //    .IsRequired();

            // configures one-to-one relationship  --> CreatePage-Blog
            //modelBuilder.Entity<Blog>()
            //    .HasOne(s => s.CreatePage)
            //    .WithOne(g => g.Blog)
            //    .IsRequired();

            //// configures one-to-one relationship  --> CreatePage-Slider
            //modelBuilder.Entity<Slider>()
            //    .HasOne(s => s.CreatePage)
            //    .WithOne(g => g.Slider)
            //    .IsRequired();

            //// configures one-to-one relationship  --> CreatePage-Promotion
            //modelBuilder.Entity<Promotion>()
            //    .HasOne(s => s.CreatePage)
            //    .WithOne(g => g.Promotion)
            //    .IsRequired();

            //// configures one-to-one relationship  --> CreatePage-Category
            //modelBuilder.Entity<Category>()
            //    .HasOne(s => s.CreatePage)
            //    .WithOne(g => g.Category)
            //    .IsRequired();


        }
       
    }
}
