using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("STN_MST", Schema = "dbo")]
  public partial class StnMst
  {
    [Key]
    public string STN_NO
    {
      get;
      set;
    }
    public string EQU_TYPE
    {
      get;
      set;
    }
    public string EQU_NO
    {
      get;
      set;
    }
    public string EQU_NAME
    {
      get;
      set;
    }
    public string AREA
    {
      get;
      set;
    }
    public string STN_DESC
    {
      get;
      set;
    }
    public decimal? STN_IDX
    {
      get;
      set;
    }
    public string STN_HOT
    {
      get;
      set;
    }
    public string STN_MODE
    {
      get;
      set;
    }
    public string ENABLE
    {
      get;
      set;
    }
    public string REMARK
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
