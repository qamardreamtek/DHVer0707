using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PLT_DTL_HIS", Schema = "dbo")]
  public partial class PltDtlHi
  {
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
    public string IN_SNO
    {
      get;
      set;
    }
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
    public string GR_DATE
    {
      get;
      set;
    }
    public string EXPIRE_DATE
    {
      get;
      set;
    }
    public string DATE_CODE
    {
      get;
      set;
    }
    public string SKU_NO
    {
      get;
      set;
    }
    public string PLANT
    {
      get;
      set;
    }
    public string STGE_LOC
    {
      get;
      set;
    }
    public string BATCH_NO
    {
      get;
      set;
    }
    public string STK_CAT
    {
      get;
      set;
    }
    public string STK_SPECIAL_IND
    {
      get;
      set;
    }
    public string STK_SPECIAL_NO
    {
      get;
      set;
    }
    public string GTIN_UNIT
    {
      get;
      set;
    }
    public decimal GTIN_QTY
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
    public decimal SKU_QTY
    {
      get;
      set;
    }
    public string COUNT_DATE
    {
      get;
      set;
    }
    public decimal? GTIN_ALO_QTY
    {
      get;
      set;
    }
    public decimal? SKU_ALO_QTY
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
