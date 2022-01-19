using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquStsLog", Schema = "dbo")]
  public partial class EquStsLog
  {
    [Key]
    public string EquNo
    {
      get;
      set;
    }
    [Key]
    public string CarNo
    {
      get;
      set;
    }
    [Key]
    public string StrDT
    {
      get;
      set;
    }
    public string EndDT
    {
      get;
      set;
    }
    [Key]
    public string EquSts
    {
      get;
      set;
    }
    public int? TotalSecs
    {
      get;
      set;
    }
  }
}
