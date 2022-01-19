using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("IN_DTL_HIS", Schema = "dbo")]
  public partial class InDtlHi
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
    public string MOVM_TYPE
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
    public string ITEM_STS
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
    public string REQM_TYPE
    {
      get;
      set;
    }
    public string STK_SEGMENT
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
    public string EXPIRE_DATE
    {
      get;
      set;
    }
    public string INSP_LOT
    {
      get;
      set;
    }
    public string GR_DATE
    {
      get;
      set;
    }
    public decimal? SKU_IN_QTY
    {
      get;
      set;
    }
    public decimal? SKU_ALO_QTY
    {
      get;
      set;
    }
    public decimal? SKU_FIN_QTY
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
    public decimal? GTIN_IN_QTY
    {
      get;
      set;
    }
    public decimal? GTIN_ALO_QTY
    {
      get;
      set;
    }
    public decimal? GTIN_FIN_QTY
    {
      get;
      set;
    }
    public string GTIN_UNIT
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
    public decimal? GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal? NET_WEIGHT
    {
      get;
      set;
    }
    public string WEIGHT_UNIT
    {
      get;
      set;
    }
    public decimal? VOLUME
    {
      get;
      set;
    }
    public string VOLUME_UNIT
    {
      get;
      set;
    }
    public string TO_NO
    {
      get;
      set;
    }
    public string TO_DATE
    {
      get;
      set;
    }
    public decimal? TO_SKU_QTY
    {
      get;
      set;
    }
    public decimal? TO_GTIN_QTY
    {
      get;
      set;
    }
    public string DATE_CODE
    {
      get;
      set;
    }
    public string START_DATE
    {
      get;
      set;
    }
    public string END_DATE
    {
      get;
      set;
    }
    public string IN_USER
    {
      get;
      set;
    }
    public string IN_DATE
    {
      get;
      set;
    }
    public string IN_LOC
    {
      get;
      set;
    }
    public string IN_STS
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
