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
    public partial class VTableList
    {
        [Column("TABLE_CATALOG")]
        [StringLength(128)]
        public string TableCatalog { get; set; }
        [Column("TABLE_SCHEMA")]
        [StringLength(128)]
        public string TableSchema { get; set; }
        [Required]
        [Column("TABLE_NAME")]
        [StringLength(128)]
        public string TableName { get; set; }
        [Column("TABLE_TYPE")]
        [StringLength(10)]
        public string TableType { get; set; }
    }
}