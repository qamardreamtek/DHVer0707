using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    [Table("GTIN_MST", Schema = "dbo")]
    public partial class GtinMst
    {
        [Key]
        public string SKU_NO
        {
            get;
            set;
        }
        public string GTIN_UNIT
        {
            get;
            set;
        }
        public string CRT_DATE
        {
            get;
            set;
        }
    }
}
