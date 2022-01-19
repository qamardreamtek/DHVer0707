using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PC_SNO", Schema = "dbo")]
  public partial class PcSno
  {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string PC_NO
    {
      get;
      set;
    }
    [Key]
    public string PC_LINE
    {
      get;
      set;
    }
    [Key]
    public string IN_SNO
    {
      get;
      set;
    }
    public string TRN_USER
    {
      get;
      set;
    }
    public string TRN_DATE
    {
      get;
      set;
    }
    public string CRT_USER
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
