﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;
using SocialMedia.Infraestructure.Configurations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SocialMedia.Infraestructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AT5OL2B;Database=SocialMedia;User = sa; Password = 175390513");
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());
        }

        
    }
}
