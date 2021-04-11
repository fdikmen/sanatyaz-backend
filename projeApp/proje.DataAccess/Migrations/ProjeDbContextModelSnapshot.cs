﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proje.DataAccess;

namespace proje.DataAccess.Migrations
{
    [DbContext(typeof(ProjeDbContext))]
    partial class ProjeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.EntityFrameworkCore.AutoHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Changed")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<string>("RowId")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("AutoHistory");
                });

            modelBuilder.Entity("proje.Entities.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("mediaUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("proje.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("proje.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("GetHomepage")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Subtitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("proje.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("iconClass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("proje.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("proje.Entities.Constant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EMail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IconClass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Shift")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Whatsapp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("YoutubeUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Constants");
                });

            modelBuilder.Entity("proje.Entities.CreatePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("CreatePages");
                });

            modelBuilder.Entity("proje.Entities.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TheEndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("proje.Entities.FormArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("FormElementId")
                        .HasColumnType("int");

                    b.Property<int>("FormUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.HasIndex("FormUserId");

                    b.ToTable("FormArchives");
                });

            modelBuilder.Entity("proje.Entities.FormElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isRequired")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormElements");
                });

            modelBuilder.Entity("proje.Entities.FormElementItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FormElementId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.ToTable("FormElementItems");
                });

            modelBuilder.Entity("proje.Entities.FormUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("FormUsers");
                });

            modelBuilder.Entity("proje.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("proje.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Changed")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<string>("RowId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TableName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("proje.Entities.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Checked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("proje.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("GetHomepage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("iconClass")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("imageUrl")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("mainMenuId")
                        .HasColumnType("int");

                    b.Property<string>("menuName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("mainMenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("proje.Entities.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Job")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MailUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("proje.Entities.PhotoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("PhotoCategories");
                });

            modelBuilder.Entity("proje.Entities.PhotoGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PhotoCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoCategoryId");

                    b.ToTable("PhotoGalleries");
                });

            modelBuilder.Entity("proje.Entities.Popup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("popupUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Popups");
                });

            modelBuilder.Entity("proje.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("GetHomepage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("mediaUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("promotionBoxSize")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("promotionSubtitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("promotionText")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("promotionTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("promotionUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("proje.Entities.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Purposes");
                });

            modelBuilder.Entity("proje.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("mediaUrl")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("sliderSubtitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sliderText")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("sliderTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("sliderUrl")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("proje.Entities.Statement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("proje.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EMail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("proje.Entities.Comment", b =>
                {
                    b.HasOne("proje.Entities.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.CreatePage", b =>
                {
                    b.HasOne("proje.Entities.Menu", "Menu")
                        .WithMany("CreatePages")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.FormArchive", b =>
                {
                    b.HasOne("proje.Entities.FormElement", "FormElement")
                        .WithMany("FormArchives")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proje.Entities.FormUser", "FormUser")
                        .WithMany("FormArchives")
                        .HasForeignKey("FormUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.FormElement", b =>
                {
                    b.HasOne("proje.Entities.Form", "Form")
                        .WithMany("FormElements")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.FormElementItem", b =>
                {
                    b.HasOne("proje.Entities.FormElement", "FormElement")
                        .WithMany("FormElementItems")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.Like", b =>
                {
                    b.HasOne("proje.Entities.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proje.Entities.Menu", b =>
                {
                    b.HasOne("proje.Entities.Menu", "mainMenu")
                        .WithMany()
                        .HasForeignKey("mainMenuId");
                });

            modelBuilder.Entity("proje.Entities.PhotoGallery", b =>
                {
                    b.HasOne("proje.Entities.PhotoCategory", "PhotoCategory")
                        .WithMany("PhotoGalleries")
                        .HasForeignKey("PhotoCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
