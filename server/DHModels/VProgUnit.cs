// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RadzenDh5.DHModels
{
    [Keyless]
    public partial class VProgUnit
    {
        [Required]
        [Column("DISP")]
        [StringLength(111)]
        public string Disp { get; set; }
        [Required]
        [Column("PROG_ID")]
        [StringLength(10)]
        public string ProgId { get; set; }
        [Column("PROG_NAME")]
        [StringLength(100)]
        public string ProgName { get; set; }
        [Required]
        [Column("PROG_TYPE")]
        [StringLength(1)]
        public string ProgType { get; set; }
        [Column("PARENT_ID")]
        [StringLength(10)]
        public string ParentId { get; set; }
        [Required]
        [Column("PROG_NODE")]
        [StringLength(1)]
        public string ProgNode { get; set; }
        [Column("PROG_PATH")]
        [StringLength(200)]
        public string ProgPath { get; set; }
        [Column("PROG_SNO", TypeName = "decimal(2, 0)")]
        public decimal ProgSno { get; set; }
        [Required]
        [Column("ENABLE")]
        [StringLength(1)]
        public string Enable { get; set; }
        [Column("REMARK")]
        public string Remark { get; set; }
        [Required]
        [Column("TRN_USER")]
        [StringLength(50)]
        public string TrnUser { get; set; }
        [Required]
        [Column("TRN_DATE")]
        [StringLength(20)]
        public string TrnDate { get; set; }
        [Required]
        [Column("CRT_USER")]
        [StringLength(50)]
        public string CrtUser { get; set; }
        [Required]
        [Column("CRT_DATE")]
        [StringLength(20)]
        public string CrtDate { get; set; }
        [Column("TW_NAME")]
        [StringLength(100)]
        public string TwName { get; set; }
        [Column("CN_NAME")]
        [StringLength(100)]
        public string CnName { get; set; }
        [Column("TH_NAME")]
        [StringLength(100)]
        public string ThName { get; set; }
        [Column("VN_NAME")]
        [StringLength(100)]
        public string VnName { get; set; }
    }
}