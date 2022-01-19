using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("OUT_SNO_HIS", Schema = "dbo")]
  public partial class OutSnoHi
  {
    public string OUT_SNO
    {
      get;
      set;
    }
    public string WHSE_NO
    {
      get;
      set;
    }
    public string OUT_NO
    {
      get;
      set;
    }
    public string OUT_LINE
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
    public string REQM_LINE
    {
      get;
      set;
    }
    public string PICKED_USER
    {
      get;
      set;
    }
    public string PICKED_DATE
    {
      get;
      set;
    }
    public decimal? PICKED_QTY
    {
      get;
      set;
    }
    public string SU_ID_FROM
    {
      get;
      set;
    }
    public string SU_ID_TO
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
