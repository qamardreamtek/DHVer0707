﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RadzenDh5.DHModels
{
    [Keyless]
    public partial class VUserProgByGroup
    {
        [Required]
        [Column("USER_ID")]
        [StringLength(20)]
        public string UserId { get; set; }
        [Required]
        [Column("PROG_ID")]
        [StringLength(10)]
        public string ProgId { get; set; }
        [Required]
        [Column("GROUP_ID")]
        [StringLength(50)]
        public string GroupId { get; set; }
        [Required]
        [Column("GROUP_WRT_ENABLE")]
        [StringLength(1)]
        public string GroupWrtEnable { get; set; }
    }
}