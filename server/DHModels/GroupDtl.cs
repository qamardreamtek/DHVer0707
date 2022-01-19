﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RadzenDh5.DHModels
{
    [Table("GROUP_DTL")]
    public partial class GroupDtl
    {
        [Key]
        [Column("GROUP_ID")]
        [StringLength(50)]
        public string GroupId { get; set; }
        [Key]
        [Column("USER_ID")]
        [StringLength(20)]
        public string UserId { get; set; }
        [Column("USER_NAME")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("DEPT_NAME")]
        [StringLength(50)]
        public string DeptName { get; set; }
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