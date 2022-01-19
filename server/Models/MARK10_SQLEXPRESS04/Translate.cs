using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
    [Table("TRANSLATE", Schema = "dbo")]
    public partial class Translate
    {
        public string EN_TEXT
        {
            get;
            set;
        }
        public string TW_TEXT
        {
            get;
            set;
        }
        public string CN_TEXT
        {
            get;
            set;
        }
        public string TH_TEXT
        {
            get;
            set;
        }
        public string VN_TEXT
        {
            get;
            set;
        }
        [Key]
        public string TEXT
        {
            get;
            set;
        }
    }
}
