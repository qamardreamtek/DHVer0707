using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquCodeDef", Schema = "dbo")]
  public partial class EquCodeDef
  {
    [Key]
    public string CodeType
    {
      get;
      set;
    }
    [Key]
    public string Code
    {
      get;
      set;
    }
    public string Desc_TW
    {
      get;
      set;
    }
    public string Desc_EN
    {
      get;
      set;
    }
  }
}
