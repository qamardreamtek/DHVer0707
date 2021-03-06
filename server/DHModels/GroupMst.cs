// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RadzenDh5.DHModels
{
    [Table("GROUP_MST")]
    public partial class GroupMst
    {
        [Key]
        [Column("GROUP_ID")]
        [StringLength(50)]
        public string GroupId { get; set; }
        [Required]
        [Column("GROUP_NAME")]
        [StringLength(50)]
        public string GroupName { get; set; }
        [Required]
        [Column("OWNER_ID")]
        [StringLength(20)]
        public string OwnerId { get; set; }
        [Column("OWNER_NAME")]
        [StringLength(50)]
        public string OwnerName { get; set; }
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
    }
}