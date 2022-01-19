using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SKU_MST_HIS", Schema = "dbo")]
  public partial class SkuMstHi
  {
    public string SKU_NO
    {
      get;
      set;
    }
    public string EAN13_NO
    {
      get;
      set;
    }
    public string SKU_NAME
    {
      get;
      set;
    }
    public string SKU_DESC
    {
      get;
      set;
    }
    public string SKU_BRAND
    {
      get;
      set;
    }
    public string SKU_CAT
    {
      get;
      set;
    }
    public string SKU_TYPE
    {
      get;
      set;
    }
    public string SKU_INDUSTRY
    {
      get;
      set;
    }
    public string SKU_GROUP
    {
      get;
      set;
    }
    public decimal? SKU_GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal? SKU_NET_WEIGHT
    {
      get;
      set;
    }
    public string SKU_WEIGHT_UNIT
    {
      get;
      set;
    }
    public decimal? SKU_VOLUME
    {
      get;
      set;
    }
    public string SKU_VOLUME_UNIT
    {
      get;
      set;
    }
    public string GTIN_NO
    {
      get;
      set;
    }
    public string GTIN_CAT
    {
      get;
      set;
    }
    public decimal? SKU_LENGTH
    {
      get;
      set;
    }
    public decimal? SKU_WIDTH
    {
      get;
      set;
    }
    public decimal? SKU_HEIGHT
    {
      get;
      set;
    }
    public string SKU_DIM_UNIT
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
    public string SKU_BATCH
    {
      get;
      set;
    }
    public string SKU_LOC_SIZE
    {
      get;
      set;
    }
    public string SKU_LOC_HOT
    {
      get;
      set;
    }
    public decimal? MIN_SHELF_LIFE
    {
      get;
      set;
    }
    public decimal? MAX_SHELF_LIFE
    {
      get;
      set;
    }
    public string VALID_DATE_FROM
    {
      get;
      set;
    }
    public string VALID_DATE_TO
    {
      get;
      set;
    }
    public string SKU_BLOCKED
    {
      get;
      set;
    }
    public string SKU_SNO_IND
    {
      get;
      set;
    }
    public string OLD_SKU_NO
    {
      get;
      set;
    }
    public string STGE_CONDITION
    {
      get;
      set;
    }
    public string CAT_GROUP
    {
      get;
      set;
    }
    public string TP_GROUP
    {
      get;
      set;
    }
    public string DIVISION
    {
      get;
      set;
    }
    public string LABEL_TYPE
    {
      get;
      set;
    }
    public string LABEL_FORM
    {
      get;
      set;
    }
    public string SOURCE_SUPPLY
    {
      get;
      set;
    }
    public string SEASON
    {
      get;
      set;
    }
    public string PRODUCT_HIERACHY
    {
      get;
      set;
    }
    public string CAD_IND
    {
      get;
      set;
    }
    public string XSITE_STS
    {
      get;
      set;
    }
    public string XDISTR_STS
    {
      get;
      set;
    }
    public string XSITE_DATE
    {
      get;
      set;
    }
    public string XDISTR_DATE
    {
      get;
      set;
    }
    public string TAX_CLASSIFICATION
    {
      get;
      set;
    }
    public string CONTENT_UNIT
    {
      get;
      set;
    }
    public decimal? NET_CONTENT
    {
      get;
      set;
    }
    public decimal? COMPARISON_PRICE
    {
      get;
      set;
    }
    public decimal? GROSS_CONTENT
    {
      get;
      set;
    }
    public string DANGEROUS_IND
    {
      get;
      set;
    }
    public string BATCH_IND
    {
      get;
      set;
    }
    public string PERIOD_SLED
    {
      get;
      set;
    }
    public string ROUND_SLED
    {
      get;
      set;
    }
    public string ASSOR_TYPE
    {
      get;
      set;
    }
    public string WH_SKU_GROUP
    {
      get;
      set;
    }
    public string COUNTRY
    {
      get;
      set;
    }
    public string LOAD_UNIT_GROUP
    {
      get;
      set;
    }
    public string FREE_CHAR
    {
      get;
      set;
    }
    public string ZMATERIAL
    {
      get;
      set;
    }
    public string XPLANT_STS
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
