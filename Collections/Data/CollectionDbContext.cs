﻿using CollectionPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionPR.Data;

public sealed class CollectionDbContext : IdentityDbContext<User>
{
    private readonly IConfiguration configuration;
    
    public DbSet<Collection> Collections { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    public CollectionDbContext(DbContextOptions<CollectionDbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCollectionModel(modelBuilder);
        ConfigureItemModel(modelBuilder);
        ConfigureIdentityRoles(modelBuilder);
        ConfigureLikeModel(modelBuilder);
        ConfigureCommentModel(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureIdentityRoles(ModelBuilder modelBuilder)
    {
        var adminRole = new IdentityRole("admin");
        var userRole = new IdentityRole("user");
        var superAdminRole = new IdentityRole("super admin");

        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole[] {superAdminRole, adminRole, userRole});
    }
    
    private static void ConfigureCollectionModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>(b =>
        {
            b.ToTable("Collections");
            b.HasKey(p => p.Id);
            b.Property(p => p.AuthorId).HasColumnName("AuthorId").IsRequired();
            b.Property(p => p.Title).HasColumnName("Title").IsRequired();
            b.Property(p => p.Description).HasColumnName("Description").IsRequired();
            b.Property(p => p.Theme).HasColumnName("Theme").IsRequired();
            b.Property(p => p.LastEditDate).HasColumnName("LastEditDate").IsRequired();
            b.Property(p => p.AddDates).HasColumnName("AddDates");
            b.Property(p => p.AddBrands).HasColumnName("AddBrands");
            b.Property(p => p.AddComments).HasColumnName("AddComments");
        });
    }

    private static void ConfigureItemModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(b =>
        {
            b.ToTable("Items");
            b.HasKey(p => p.Id);
            b.Property(p => p.CollectionId).HasColumnName("CollectionId").IsRequired();
            b.Property(p => p.Title).HasColumnName("Title").IsRequired();
            b.Property(p => p.Description).HasColumnName("Description").IsRequired();
            b.Property(p => p.LastEditDate).HasColumnName("LastEditDate").IsRequired();
            b.Property(p => p.Date).HasColumnName("Date");
            b.Property(p => p.Brand).HasColumnName("Brand");
        });
    }
    
    private static void ConfigureLikeModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>(b =>
        {
            b.ToTable("Like");
            b.HasKey(l => new { l.ItemId, l.UserId });
        });
    }

    private static void ConfigureCommentModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(b =>
        {
            b.ToTable("Comment");
            b.HasKey(c => c.Id);
            b.Property(c => c.UserNickName).HasColumnName("UserNickName");
            b.Property(c => c.ItemId).HasColumnName("ItemId");
            b.Property(c => c.CommentText).HasColumnName("CommentText").IsRequired();
            b.Property(c => c.CommentWhen).HasColumnName("CommentWhen").IsRequired();
        });
    }
}