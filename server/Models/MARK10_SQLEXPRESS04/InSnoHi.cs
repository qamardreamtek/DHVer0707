using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("IN_SNO_HIS", Schema = "dbo")]
  public partial class InSnoHi
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string IN_NO
    {
      get;
      set;
    }
    public string IN_LINE
    {
      get;
      set;
    }
    public string TRN_NO
    {
      get;
      set;
    }
    public string TRN_LINE
    {
      get;
      set;
    }
    public string SKU_NO
    {
      get;
      set;
    }
    public string GTIN_NO
    {
      get;
      set;
    }
    public string REQM_NO
    {
      get;
      set;
    }
    public decimal? SKU_IN_QTY
    {
      get;
      set;
    }
    public decimal? SKU_RCV_QTY
    {
      get;
      set;
    }
    public decimal? SKU_FIN_QTY
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public string SU_TYPE
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
    public string LOC_NO
    {
      get;
      set;
    }
    public string ALO_NO
    {
      get;
      set;
    }
    public string ALO_LINE
    {
      get;
      set;
    }
    public decimal? SKU_ALO_QTY
    {
      get;
      set;
    }
    public decimal? SKU_OUT_QTY
    {
      get;
      set;
    }
    public string SOURCE
    {
      get;
      set;
    }
    public string APPROVE_IND
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
    [Key]
    public string LOG_DATE
    {
      get;
      set;
    }
    public string LOG_USER
    {
      get;
      set;
    }
  }
}
