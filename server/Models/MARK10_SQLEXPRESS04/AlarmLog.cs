using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("AlarmLog", Schema = "dbo")]
  public partial class AlarmLog
  {
    [Key]
    public string EquNo
    {
      get;
      set;
    }
    [Key]
    public string AlarmCode
    {
      get;
      set;
    }
    public string AlarmSts
    {
      get;
      set;
    }
    [Key]
    public string STRDT
    {
      get;
      set;
    }
    public string CLRDT
    {
      get;
      set;
    }
    public int? TOTALSECS
    {
      get;
      set;
    }
  }
}
