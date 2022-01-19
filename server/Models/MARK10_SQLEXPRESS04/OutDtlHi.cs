using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("OUT_DTL_HIS", Schema = "dbo")]
  public partial class OutDtlHi
  {
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
    public string GTIN_NO
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
    public decimal GTIN_OUT_QTY
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
    public decimal? SKU_OUT_QTY
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
    public string GTIN_DESC
    {
      get;
      set;
    }
    public string DD_LINE
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
    public string DOC_NO
    {
      get;
      set;
    }
    public string DOC_LINE
    {
      get;
      set;
    }
    public string MOVM_TYPE
    {
      get;
      set;
    }
    public string SKU_GROUP
    {
      get;
      set;
    }
    public string TP_GROUP
    {
      get;
      set;
    }
    public string CREATEUSER
    {
      get;
      set;
    }
    public string CREATEDATE
    {
      get;
      set;
    }
    public string CREATETIME
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
    public string OUT_USER
    {
      get;
      set;
    }
    public string OUT_DATE
    {
      get;
      set;
    }
    public string OUT_LOC
    {
      get;
      set;
    }
    public string OUT_STS
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
