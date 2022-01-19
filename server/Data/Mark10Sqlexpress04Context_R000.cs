using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using RadzenDh5.Models.Mark10Sqlexpress04;



namespace RadzenDh5.Data
{
    public partial class Mark10Sqlexpress04Context : Mark10Sqlexpress04Context_PreR000
    {
        // NOTE by Mark, 05/01, P000 to be here  as well
        // NOTE by Mark, 04/30, C000 to be here  as well
        // TODO https://stackoverflow.com/questions/52182040/how-to-extend-dbcontext-with-partial-class-and-partial-onmodelcreating-method-in
        public Mark10Sqlexpress04Context(DbContextOptions<Mark10Sqlexpress04Context> options) : base(options)
        {
        }

        public Mark10Sqlexpress04Context()
        {
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl> VLocDtlMstPltDtlInDtls
        {
            get;
            set;
        }
        // NOTE by Mark, 05/03, get view def
        public DbSet<BlazorApp1.IdName> IdNames
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vc010> Vc010s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp020A> Vp020As
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B> Vp020Bs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp020MergeOutDtl> Vp020MergeOutDtls
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl> Vp020LocDtls
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp080> Vp080s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub> Vp030Subs
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VTranslate> VTranslates
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp100> Vp100s
        {
            get;
            set;
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp100>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp100>()
       .Property(p => p.PLT_CNT)
       .HasPrecision(26, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VTranslate>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
           .Property(p => p.GTIN_QTY)
           .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp080>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl>()
           .Property(p => p.SKU_QTY)
           .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020LocDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020MergeOutDtl>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020MergeOutDtl>()
           .Property(p => p.SKU_CMD_QTY)
           .HasPrecision(38, 3);
            // V_P020B

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B>()
      .Property(p => p.sku_qty)
      .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B>()
                  .Property(p => p.sku_alo_qty)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B>()
                  .Property(p => p.gtin_numerator)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020B>()
                  .Property(p => p.gtin_denominator)
                  .HasPrecision(5, 0);



            // V_P020A
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020A>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp020A>()
            .Property(p => p.SKU_CMD_QTY)
            .HasPrecision(38, 3);



            // for P060
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VLocDtlMstPltDtlInDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);


            // V_P070, NOTE by Mark, 有額外在  PLT_DTL 的基礎上, 加了幾?欄位
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
            .Property(p => p.GTIN_QTY)
            .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp070>()
                  .Property(p => p.LOC_QTY)
                  .HasPrecision(13, 3);


            // V_P030SUB
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub>()
              .Property(p => p.SKU_QTY)
              .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030Sub>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            // V_P030
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
             .Property(p => p.GTIN_OUT_QTY)
             .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp030>()
                  .Property(p => p.SKU_AVAIL_QTY)
                  .HasPrecision(38, 3);


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vc010>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vc010>()
      .Property(p => p.GTIN_MAX_QTY)
      .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vc010>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(38, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vc010>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(38, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vc010>()
                  .Property(p => p.LOC_QTY)
                  .HasPrecision(13, 3);



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CntResult>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr080>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>()
             .Property(p => p.GTIN_MAX_QTY)
             .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr050>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(38, 3);


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr080>()
              .Property(p => p.GTIN_QTY)
              .HasPrecision(38, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr080>()
                  .Property(p => p.COUNT_QTY)
                  .HasPrecision(38, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr080>()
                  .Property(p => p.DIFF_QTY)
                  .HasPrecision(38, 3);
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr070>().HasNoKey();


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>()
                  .Property(p => p.Outbound)
                  .HasPrecision(38, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>()
                  .Property(p => p.Inbound)
                  .HasPrecision(38, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>()
                  .Property(p => p.Relocation)
                  .HasPrecision(38, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr060>()
                  .Property(p => p.Total)
                  .HasPrecision(38, 0);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr070>()
            //      .Property(p => p.Outbound)
            //      .HasPrecision(38, 0);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr070>()
            //      .Property(p => p.Inbound)
            //      .HasPrecision(38, 0);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr070>()
            //      .Property(p => p.Relocation)
            //      .HasPrecision(38, 0);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr070>()
            //      .Property(p => p.Total)
            //      .HasPrecision(38, 0);



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr040>().HasNoKey();


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr040>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(38, 3);



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>()
   .HasOne(i => i.ProgMst1)
   .WithMany(i => i.ProgMsts1)
   .HasForeignKey(i => i.PARENT_ID)
   .HasPrincipalKey(i => i.PROG_ID);


            // NOTE by Mark, 04/24, V_RIGHT, 用戶-程序 權限
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VRight>().HasNoKey();


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VRight>()
                  .Property(p => p.PROG_SNO)
                  .HasPrecision(2, 0);


        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp070> Vp070s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp030> Vp030s
        {
            get;
            set;
        }


        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.CntResult> CntResult
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VRight> VRights
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr040> Vr040s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr060> Vr060s
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr070> Vr070s
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr050> Vr050s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr080> Vr080s
        {
            get;
            set;
        }
    }
}
