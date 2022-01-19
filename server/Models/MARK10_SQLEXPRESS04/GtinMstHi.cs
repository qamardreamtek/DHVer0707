using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("GTIN_MST_HIS", Schema = "dbo")]
  public partial class GtinMstHi
  {
    public string SKU_NO
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
    public string GTIN_DESC
    {
      get;
      set;
    }
    public string GTIN_CAT
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
    public decimal? GTIN_GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal? GTIN_NET_WEIGHT
    {
      get;
      set;
    }
    public string GTIN_WEIGHT_UNIT
    {
      get;
      set;
    }
    public decimal? GTIN_VOLUME
    {
      get;
      set;
    }
    public string GTIN_VOLUME_UNIT
    {
      get;
      set;
    }
    public decimal? GTIN_LENGTH
    {
      get;
      set;
    }
    public decimal? GTIN_WIDTH
    {
      get;
      set;
    }
    public decimal? GTIN_HEIGHT
    {
      get;
      set;
    }
    public string GTIN_DIM_UNIT
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
