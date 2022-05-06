using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using BuyPowerApiNew.Entities.Configuration;
using System.Threading.Tasks;
using BuyPowerApiNew.Entities.Configuration;

namespace BuyPowerApiNew.Models
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
          : base(options)
        {


        }

        public virtual DbSet<tblRequestAndResponseLog> tblRequestAndResponse { get; set; }

        public virtual DbSet<tblAuthRequestAndResponseLog> tblAuthRequestAndResponseLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tblRequestAndResponseLog>(entity =>
            {

                entity.ToTable("tblRequestAndResponseLog");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestType).IsRequired(true).IsUnicode(false).HasMaxLength(100);
                entity.Property(e => e.RequestPayload).IsRequired(true).IsUnicode(true).HasMaxLength(5000);
                entity.Property(e => e.RequestId).IsRequired(true).IsUnicode(false).HasMaxLength(50);
                entity.Property(e => e.Response).IsRequired(false).IsUnicode(true).HasMaxLength(int.MaxValue);
                entity.Property(e => e.RequestTimestamp).IsRequired(true).HasColumnType("datetime");
                entity.Property(e => e.ResponseTimestamp).IsRequired(true).HasColumnType("datetime");
                entity.Property(e => e.RequestUrl).IsRequired(true).IsUnicode(true).HasMaxLength(int.MaxValue);
                entity.Property(e => e.Client).IsRequired(true).IsUnicode(true).HasMaxLength(int.MaxValue);

            });

            modelBuilder.Entity<tblAuthRequestAndResponseLog>(entity =>
            {

                entity.ToTable("tblAuthRequestAndResponseLog");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestType).IsRequired(true).IsUnicode(false).HasMaxLength(100);
                entity.Property(e => e.RequestPayload).IsRequired(true).IsUnicode(true).HasMaxLength(5000);
                entity.Property(e => e.RequestId).IsRequired(true).IsUnicode(false).HasMaxLength(50);
                entity.Property(e => e.Response).IsRequired(false).IsUnicode(true).HasMaxLength(int.MaxValue);
                entity.Property(e => e.RequestTimestamp).IsRequired(true).HasColumnType("datetime");
                entity.Property(e => e.ResponseTimestamp).IsRequired(true).HasColumnType("datetime");

            });

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


    }
}
