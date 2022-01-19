using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("AlarmDef", Schema = "dbo")]
  public partial class AlarmDef
  {
    [Key]
    public string AlarmCode
    {
      get;
      set;
    }
    public string AlarmLevel
    {
      get;
      set;
    }
    public string AlarmDesc
    {
      get;
      set;
    }
    public string AlarmDesc_EN
    {
      get;
      set;
    }
    public string SelectFlag
    {
      get;
      set;
    }
  }
}
