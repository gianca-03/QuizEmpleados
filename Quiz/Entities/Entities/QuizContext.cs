﻿using System;
using System.Collections.Generic;
using Entities.Authentication;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class QuizContext : IdentityDbContext<ApplicationUser>
    {
        public QuizContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
