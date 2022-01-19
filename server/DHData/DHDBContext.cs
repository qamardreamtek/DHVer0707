﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using RadzenDh5.DHModels;

#nullable disable

namespace RadzenDh5.DHData
{
    public partial class DHDBContext : DbContext
    {

        public DHDBContext()
        {
        }

        public DHDBContext(DbContextOptions<DHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<GroupDtl> GroupDtl { get; set; }
        public virtual DbSet<GroupMst> GroupMst { get; set; }
        public virtual DbSet<GroupWrt> GroupWrt { get; set; }
        public virtual DbSet<ProgMst> ProgMst { get; set; }
        public virtual DbSet<ProgWrt> ProgWrt { get; set; }
        public virtual DbSet<UserMst> UserMst { get; set; }
        public virtual DbSet<VProgCat> VProgCat { get; set; }
        public virtual DbSet<VProgUnit> VProgUnit { get; set; }
        public virtual DbSet<VTableList> VTableList { get; set; }
        public virtual DbSet<VUserProgByGroup> VUserProgByGroup { get; set; }
        public virtual DbSet<VUserRole> VUserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<GroupDtl>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId });

                entity.Property(e => e.GroupId).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");
            });

            modelBuilder.Entity<GroupMst>(entity =>
            {
                entity.Property(e => e.GroupId).IsUnicode(false);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.OwnerId).IsUnicode(false);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");
            });

            modelBuilder.Entity<GroupWrt>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.ProgId });

                entity.Property(e => e.GroupId).IsUnicode(false);

                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.ApproveWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.DeleteWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ExportWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ImportWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrintWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.QueryWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.UpdateWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ProgMst>(entity =>
            {
                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentId).IsUnicode(false);

                entity.Property(e => e.ProgNode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProgType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");
            });

            modelBuilder.Entity<ProgWrt>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProgId });

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.ApproveWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.DeleteWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ExportWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ImportWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PrintWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.QueryWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.UpdateWrt)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UserMst>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.CrtDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.Language)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('EN')");

                entity.Property(e => e.LastDate).IsUnicode(false);

                entity.Property(e => e.Mobile).IsUnicode(false);

                entity.Property(e => e.PswdDate).IsUnicode(false);

                entity.Property(e => e.Telphone).IsUnicode(false);

                entity.Property(e => e.TrnDate)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.UserPswd).IsUnicode(false);
            });

            modelBuilder.Entity<VProgCat>(entity =>
            {
                entity.ToView("V_PROG_CAT");

                entity.Property(e => e.CrtDate).IsUnicode(false);

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParentId).IsUnicode(false);

                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.ProgNode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProgType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate).IsUnicode(false);
            });

            modelBuilder.Entity<VProgUnit>(entity =>
            {
                entity.ToView("V_PROG_UNIT");

                entity.Property(e => e.CrtDate).IsUnicode(false);

                entity.Property(e => e.Enable)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ParentId).IsUnicode(false);

                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.ProgNode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProgType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrnDate).IsUnicode(false);
            });

            modelBuilder.Entity<VTableList>(entity =>
            {
                entity.ToView("v_table_list");

                entity.Property(e => e.TableType).IsUnicode(false);
            });

            modelBuilder.Entity<VUserProgByGroup>(entity =>
            {
                entity.ToView("V_USER_PROG_BY_GROUP");

                entity.Property(e => e.GroupId).IsUnicode(false);

                entity.Property(e => e.GroupWrtEnable)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProgId).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<VUserRole>(entity =>
            {
                entity.ToView("v_user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}