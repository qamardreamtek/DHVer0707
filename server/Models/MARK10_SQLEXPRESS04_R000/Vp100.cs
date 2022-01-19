using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_P100", Schema = "dbo")]
  public partial class Vp100
  {
    public string EQU_NO
    {
      get;
      set;
    }
    public string LOC_NO
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public decimal? PLT_CNT
    {
      get;
      set;
    }
    public string REMARK
    {
      get;
      set;
    }
  }
}
