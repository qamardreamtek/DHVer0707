using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
//namespace RadenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_P060", Schema = "dbo")]
  public partial class Vp060
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string STGE_TYPE
    {
      get;
      set;
    }
    public string STGE_BIN
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
    public string LOC_NO
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
    public string SKU_NO
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
    public decimal? GTIN_NUMERATOR
    {
      get;
      set;
    }
    public decimal? GTIN_DENOMINATOR
    {
      get;
      set;
    }
    public decimal GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal NET_WEIGHT
    {
      get;
      set;
    }
    public string WEIGHT_UNIT
    {
      get;
      set;
    }
    public decimal VOLUME
    {
      get;
      set;
    }
    public string VOLUME_UNIT
    {
      get;
      set;
    }
    public decimal GTIN_ALO_QTY
    {
      get;
      set;
    }
    public decimal SKU_ALO_QTY
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
    public string EQU_NO
    {
      get;
      set;
    }
    public string LOC_STS
    {
      get;
      set;
    }
  }
}
