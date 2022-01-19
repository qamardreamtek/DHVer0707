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
    public partial class Mark10Sqlexpress04Context_PreR000 : Microsoft.EntityFrameworkCore.DbContext
    {
        public Mark10Sqlexpress04Context_PreR000(DbContextOptions<Mark10Sqlexpress04Context> options) : base(options)
        {
        }

        public Mark10Sqlexpress04Context_PreR000()
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrtHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.RptR030>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>().HasNoKey();

            // DEBUG, by Mark, 05/16
            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Translate>().HasNoKey();

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMstHi>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VTableList>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VUserProgByGroup>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.VUserRole>().HasNoKey();

            //NOTE by Mark, 04/28, 是否可以因此顯示出 Rec Num?
            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr030>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr030>()
       .HasKey(c => new { c.TRN_DATE, c.SKU_NO });

            // NOTE by Mark, by hand, 04/17
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>().HasNoKey();


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vp060>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);
            this.OnModelBuilding(builder);






            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Xxx>().HasNoKey();
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmLog>().HasKey(table => new
            {
                table.EquNo,
                table.AlarmCode,
                table.STRDT
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst>().HasKey(table => new
            {
                table.CMD_DATE,
                table.CMD_SNO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmd>().HasKey(table => new
            {
                table.CmdSno,
                table.EquNo,
                table.CmdMode,
                table.Source
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>().HasKey(table => new
            {
                table.LogDT,
                table.CmdSno,
                table.EquNo,
                table.CmdMode
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdHi>().HasKey(table => new
            {
                table.HISDT,
                table.CmdSno,
                table.EquNo,
                table.CmdMode,
                table.Source
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef>().HasKey(table => new
            {
                table.CodeType,
                table.Code
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog>().HasKey(table => new
            {
                table.EquNo,
                table.CarNo,
                table.StrDT,
                table.EquMode
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>().HasKey(table => new
            {
                table.EquNo,
                table.D0,
                table.D1,
                table.D14,
                table.LogDT
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquPlcDatum>().HasKey(table => new
            {
                table.EquNo,
                table.SerialNo
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog>().HasKey(table => new
            {
                table.EquNo,
                table.CarNo,
                table.StrDT,
                table.EquSts
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>().HasKey(table => new
            {
                table.TrnDT,
                table.CmdSno,
                table.EquNo,
                table.CmdMode
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl>().HasKey(table => new
            {
                table.GROUP_ID,
                table.USER_ID
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt>().HasKey(table => new
            {
                table.GROUP_ID,
                table.PROG_ID
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>().HasKey(table => new
            {
                table.SKU_NO,
                table.GTIN_UNIT
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>().HasKey(table => new
            {
                table.WHSE_NO,
                table.IN_NO,
                table.IN_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>().HasKey(table => new
            {
                table.WHSE_NO,
                table.IN_NO,
                table.IN_LINE,
                table.SU_ID,
                table.IN_SNO1
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>().HasKey(table => new
            {
                table.IN_SNO,
                table.LOG_DATE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>().HasKey(table => new
            {
                table.WHSE_NO,
                table.SU_ID,
                table.PLANT,
                table.STGE_LOC,
                table.SKU_NO,
                table.BATCH_NO,
                table.STK_CAT,
                table.STK_SPECIAL_IND,
                table.STK_SPECIAL_NO,
                table.GTIN_UNIT
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>().HasKey(table => new
            {
                table.WHSE_NO,
                table.LOC_NO,
                table.ZONE_NO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.MsgLang>().HasKey(table => new
            {
                table.MSG_ID,
                table.LANGUAGE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>().HasKey(table => new
            {
                table.WHSE_NO,
                table.OUT_NO,
                table.OUT_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>().HasKey(table => new
            {
                table.WHSE_NO,
                table.OUT_NO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PC_NO,
                table.PC_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcSno>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PC_NO,
                table.PC_LINE,
                table.IN_SNO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PCK_NO,
                table.PCK_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMst>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PCK_NO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PCK_NO,
                table.IN_SNO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PIC_NO,
                table.PIC_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>().HasKey(table => new
            {
                table.WHSE_NO,
                table.PIC_NO
            });

            // Note by Mark, 06/12
            // 如果有機會, 確認是否第一版DB是如此
            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>().HasKey(table => new
            //{
            //    table.WHSE_NO,
            //    table.PIC_NO,
            //    table.IN_SNO
            //});
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>().HasKey(table => new {
                table.WHSE_NO,
                table.PIC_NO,
                table.PIC_LINE,
                table.IN_SNO,
                table.IN_NO,
                table.IN_LINE
            });

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.STGE_TYPE)
                  .HasDefaultValueSql("('ATR')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.STGE_BIN)
                  .HasDefaultValueSql("('ASRSA00000')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.GTIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.SKU_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.SKU_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.COUNT_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.PIC_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
                  .Property(p => p.COUNT_QTY)
                  .HasPrecision(13, 3);
            this.OnModelBuilding(builder);


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>().HasKey(table => new
            {
                table.SU_ID,
                table.IN_SNO,
                table.WHSE_NO,
                table.IN_NO,
                table.IN_LINE,
                table.STK_CAT,
                table.STK_SPECIAL_IND,
                table.STK_SPECIAL_NO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>().HasKey(table => new
            {
                table.USER_ID,
                table.PROG_ID
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>().HasKey(table => new
            {
                table.WHSE_NO,
                table.SKU_NO,
                table.GTIN_UNIT,
                table.SU_TYPE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>().HasKey(table => new
            {
                table.WHSE_NO,
                table.TX_NO,
                table.TX_LINE
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxSno>().HasKey(table => new
            {
                table.TX_NO,
                table.TX_LINE,
                table.IN_SNO
            });
            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserLog>().HasKey(table => new
            {
                table.LOG_DATE,
                table.LOG_TYPE,
                table.USER_ID,
                table.PROG_ID
            });

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmDef>()
                  .Property(p => p.AlarmLevel)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmDef>()
                  .Property(p => p.AlarmDesc)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmDef>()
                  .Property(p => p.AlarmDesc_EN)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmLog>()
                  .Property(p => p.CLRDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmLog>()
                  .Property(p => p.TOTALSECS)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.CtrlH>()
                  .Property(p => p.TrnDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.FBank)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.FBayLevel)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.TBank)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.TBayLevel)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.TransferInfo)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.WriteBuffer)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.WritePLC)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.StartAction)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.Cycle1)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.Fork1)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.LoadPresence_On)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.CSTPresence_On)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.Cycle2)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.Fork2)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.LoadPresence_Off)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.CSTPresence_Off)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.CmdFinish)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.CompleteCode)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.PLCTimerCount)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog>()
                  .Property(p => p.Notes)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdHi>()
                  .Property(p => p.HISDT)
                  .HasDefaultValueSql("(CONVERT([varchar],getdate(),(121)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef>()
                  .Property(p => p.Desc_TW)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef>()
                  .Property(p => p.Desc_EN)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog>()
                  .Property(p => p.CarNo)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog>()
                  .Property(p => p.EndDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog>()
                  .Property(p => p.TotalSecs)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D2)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D3)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D4)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D5)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D6)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D7)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D8)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D9)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D10)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D11)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D12)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.D13)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi>()
                  .Property(p => p.LogDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquPlcDatum>()
                  .Property(p => p.EquType)
                  .HasDefaultValueSql("('1')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquPlcDatum>()
                  .Property(p => p.EquPlcData)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquPlcDatum>()
                  .Property(p => p.TrnDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog>()
                  .Property(p => p.CarNo)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog>()
                  .Property(p => p.EndDT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog>()
                  .Property(p => p.TotalSecs)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CmdSno)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.EquNo)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CmdMode)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CmdSts)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.Source)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.Destination)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.LocSize)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CompleteCode)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CompleteIndex)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.CarNo)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog>()
                  .Property(p => p.TrnDesc)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_LENGTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_WIDTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_HEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_DIM_UNIT)
                  .HasDefaultValueSql("('CM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.ITEM_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.IN_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.PRIORITY)
                  .HasDefaultValueSql("((50))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.STGE_TYPE_TO)
                  .HasDefaultValueSql("('ATR')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.STGE_BIN_TO)
                  .HasDefaultValueSql("('ASRSA00000')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.PLAN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.ITEM_COUNT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.IN_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_RCV_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.IN_SNO1)
                  .HasDefaultValueSql("('**********')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.BATCH_NO)
                  .HasDefaultValueSql("('')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.STK_CAT)
                  .HasDefaultValueSql("(' ')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.STK_SPECIAL_IND)
                  .HasDefaultValueSql("('')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.STK_SPECIAL_NO)
                  .HasDefaultValueSql("('')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.SKU_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.WHSE_NO)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.ZONE_NO)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LANE_NO)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_ASRS)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_STS)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_OSTS)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.AVAIL)
                  .HasDefaultValueSql("((100))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.DEPTH)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_SIZE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_TYPE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_ABC)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_SPECIAL)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_HOT)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_RCV)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_STOCK)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_QC)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_NG)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_RETURN)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_SORT)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_PICK)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_STAGE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LOC_DEL)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.COUNT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasDefaultValueSql("((1))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.OUT_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.OUT_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSno>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSno>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.PC_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.PC_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.PCK_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMst>()
                  .Property(p => p.PCK_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.STGE_TYPE)
                  .HasDefaultValueSql("('ATR')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.STGE_BIN)
                  .HasDefaultValueSql("('ASRSA00000')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.WMSLOC_IND)
                  .HasDefaultValueSql("('X')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.PIC_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>()
                  .Property(p => p.PIC_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.STGE_TYPE)
            //      .HasDefaultValueSql("('ATR')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.STGE_BIN)
            //      .HasDefaultValueSql("('ASRSA00000')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.GTIN_QTY)
            //      .HasDefaultValueSql("((0))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.SKU_UNIT)
            //      .HasDefaultValueSql("('EA')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.SKU_QTY)
            //      .HasDefaultValueSql("((0))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.COUNT_QTY)
            //      .HasDefaultValueSql("((0))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.PIC_STS)
            //      .HasDefaultValueSql("('0')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.SOURCE)
            //      .HasDefaultValueSql("('0')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.APPROVE_IND)
            //      .HasDefaultValueSql("('Y')");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.TRN_DATE)
            //      .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.CRT_DATE)
            //      .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi>()
            //      .Property(p => p.LOG_DATE)
            //      .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrtHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_GROSS_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_NET_WEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_WEIGHT_UNIT)
                  .HasDefaultValueSql("('KG')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_VOLUME)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_VOLUME_UNIT)
                  .HasDefaultValueSql("('CCM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_LENGTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_WIDTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_HEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_DIM_UNIT)
                  .HasDefaultValueSql("('CM')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_BATCH)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_LOC_SIZE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_LOC_HOT)
                  .HasDefaultValueSql("('M')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.MIN_SHELF_LIFE)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.MAX_SHELF_LIFE)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.VALID_DATE_FROM)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.VALID_DATE_TO)
                  .HasDefaultValueSql("('9999-12-31 23:59:59')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_BLOCKED)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_SNO_IND)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SKU_UNIT)
                  .HasDefaultValueSql("('EA')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_LENGTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_WIDTH)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_HEIGHT)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SKU_MAX_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_MAX_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_LAYER)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_LAYER_QTY)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>()
                  .Property(p => p.SNO)
                  .HasDefaultValueSql("((0))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](8),getdate(),(112)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.StnMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.StnMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.TX_STS)
                  .HasDefaultValueSql("('0')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.SOURCE)
                  .HasDefaultValueSql("('1')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.APPROVE_IND)
                  .HasDefaultValueSql("('Y')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMst>()
                  .Property(p => p.LANGUAGE)
                  .HasDefaultValueSql("('EN')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMst>()
                  .Property(p => p.ENABLE)
                  .HasDefaultValueSql("('N')");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMst>()
                  .Property(p => p.TRN_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMst>()
                  .Property(p => p.CRT_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.UserMstHi>()
                  .Property(p => p.LOG_DATE)
                  .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");


            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.AlarmLog>()
                  .Property(p => p.TOTALSECS)
                  .HasPrecision(10, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog>()
                  .Property(p => p.TotalSecs)
                  .HasPrecision(10, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog>()
                  .Property(p => p.TotalSecs)
                  .HasPrecision(10, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst>()
                  .Property(p => p.GTIN_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi>()
                  .Property(p => p.GTIN_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SKU_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.TO_SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtl>()
                  .Property(p => p.TO_GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.SKU_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GTIN_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.TO_SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi>()
                  .Property(p => p.TO_GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.PRIORITY)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.ITEM_COUNT)
                  .HasPrecision(10, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMst>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.PRIORITY)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.ITEM_COUNT)
                  .HasPrecision(10, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_RCV_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSno>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.SKU_IN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.SKU_RCV_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.ROW_X)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.BAY_Y)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.LVL_Z)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMst>()
                  .Property(p => p.AVAIL)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>()
                  .Property(p => p.ROW_X)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>()
                  .Property(p => p.BAY_Y)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>()
                  .Property(p => p.LVL_Z)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi>()
                  .Property(p => p.AVAIL)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GTIN_NUMERATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GTIN_DENOMINATOR)
                  .HasPrecision(5, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GTIN_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.SKU_OUT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMst>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMstHi>()
                  .Property(p => p.GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutMstHi>()
                  .Property(p => p.NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSno>()
                  .Property(p => p.PICKED_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi>()
                  .Property(p => p.PICKED_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PcLog>()
                  .Property(p => p.SKU_QTY_TO)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSno>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>()
                  .Property(p => p.GTIN_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi>()
                  .Property(p => p.SKU_FIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl>()
                  .Property(p => p.COUNT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi>()
                  .Property(p => p.COUNT_QTY)
                  .HasPrecision(13, 3);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.GTIN_QTY)
            //      .HasPrecision(13, 3);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.SKU_QTY)
            //      .HasPrecision(13, 3);

            //builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSno>()
            //      .Property(p => p.COUNT_QTY)
            //      .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi>()
                  .Property(p => p.COUNT_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>()
                  .Property(p => p.SKU_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>()
                  .Property(p => p.GTIN_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi>()
                  .Property(p => p.SKU_ALO_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst>()
                  .Property(p => p.PROG_SNO)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi>()
                  .Property(p => p.PROG_SNO)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.RptR030>()
                  .Property(p => p.RCV_QTY)
                  .HasPrecision(38, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.SKU_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.MIN_SHELF_LIFE)
                  .HasPrecision(4, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.MAX_SHELF_LIFE)
                  .HasPrecision(4, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.NET_CONTENT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.COMPARISON_PRICE)
                  .HasPrecision(5, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst>()
                  .Property(p => p.GROSS_CONTENT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_GROSS_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_NET_WEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_VOLUME)
                  .HasPrecision(15, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.SKU_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.MIN_SHELF_LIFE)
                  .HasPrecision(4, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.MAX_SHELF_LIFE)
                  .HasPrecision(4, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.NET_CONTENT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.COMPARISON_PRICE)
                  .HasPrecision(5, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi>()
                  .Property(p => p.GROSS_CONTENT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SU_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.SKU_MAX_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_MAX_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_LAYER)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut>()
                  .Property(p => p.GTIN_LAYER_QTY)
                  .HasPrecision(3, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.SU_LENGTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.SU_WIDTH)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.SU_HEIGHT)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.SKU_MAX_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.GTIN_MAX_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.GTIN_LAYER)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi>()
                  .Property(p => p.GTIN_LAYER_QTY)
                  .HasPrecision(2, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl>()
                  .Property(p => p.SNO)
                  .HasPrecision(6, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.StnMst>()
                  .Property(p => p.STN_IDX)
                  .HasPrecision(6, 0);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.TxLog>()
                  .Property(p => p.GTIN_QTY)
                  .HasPrecision(13, 3);

            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Vr030>()
                  .Property(p => p.RCV_QTY)
                  .HasPrecision(38, 3);



            builder.Entity<RadzenDh5.Models.Mark10Sqlexpress04.Xxx>()
                  .Property(p => p.x1)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.AlarmDef> AlarmDefs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.AlarmLog> AlarmLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.CmdMst> CmdMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.CmdMstHi> CmdMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.CtrlH> CtrlHs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquCmd> EquCmds
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdDetailLog> EquCmdDetailLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquCmdHi> EquCmdHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquCodeDef> EquCodeDefs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquModeLog> EquModeLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquMplcCmdHi> EquMplcCmdHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquPlcDatum> EquPlcData
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquStsLog> EquStsLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.EquTrnLog> EquTrnLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtl> GroupDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupDtlHi> GroupDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> GroupMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupMstHi> GroupMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrt> GroupWrts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GroupWrtHi> GroupWrtHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GtinMst> GtinMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.GtinMstHi> GtinMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InDtl> InDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InDtlHi> InDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InMst> InMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InMstHi> InMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InSno> InSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.InSnoHi> InSnoHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.LocDtl> LocDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.LocDtlHi> LocDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.LocMst> LocMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.LocMstHi> LocMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.MsgLang> MsgLangs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutDtl> OutDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutDtlHi> OutDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutMst> OutMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutMstHi> OutMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutSno> OutSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.OutSnoHi> OutSnoHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PcLog> PcLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PcSno> PcSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckDtl> PckDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckDtlHi> PckDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckMst> PckMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckMstHi> PckMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckSno> PckSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PckSnoHi> PckSnoHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicDtl> PicDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicDtlHi> PicDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicMst> PicMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicMstHi> PicMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicSno> PicSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PicSnoHi> PicSnoHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PltDtl> PltDtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.PltDtlHi> PltDtlHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.ProgMst> ProgMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.ProgMstHi> ProgMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrt> ProgWrts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.ProgWrtHi> ProgWrtHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.RptR030> RptR030s
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.SkuMst> SkuMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.SkuMstHi> SkuMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.SkuSut> SkuSuts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.SkuSutHi> SkuSutHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.SnoCtl> SnoCtls
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.StnMst> StnMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Translate> Translates
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.TxLog> TxLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.TxSno> TxSnos
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.UserLog> UserLogs
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> UserMsts
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.UserMstHi> UserMstHis
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VTableList> VTableLists
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VUserProgByGroup> VUserProgByGroups
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.VUserRole> VUserRoles
        {
            get;
            set;
        }

        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vr030> Vr030s
        {
            get;
            set;
        }

        // NOTE by Mark, by hand, 04/17


        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Vp060> Vp060s
        {
            get;
            set;
        }
        public DbSet<RadzenDh5.Models.Mark10Sqlexpress04.Xxx> Xxxes
        {
            get;
            set;
        }
    }
}
