using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SKU_SUT", Schema = "dbo")]
  public partial class SkuSut
  {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string SKU_NO
    {
      get;
      set;
    }
    [Key]
    public string GTIN_UNIT
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
    public string SKU_UNIT
    {
      get;
      set;
    }
    [Key]
    public string SU_TYPE
    {
      get;
      set;
    }
    public string SU_UNIT
    {
      get;
      set;
    }
    public decimal SU_LENGTH
    {
      get;
      set;
    }
    public decimal SU_WIDTH
    {
      get;
      set;
    }
    public decimal SU_HEIGHT
    {
      get;
      set;
    }
    public string SU_DIM_UNIT
    {
      get;
      set;
    }
    public decimal SKU_MAX_QTY
    {
      get;
      set;
    }
    public string GTIN_NO
    {
      get;
      set;
    }
    public decimal GTIN_MAX_QTY
    {
      get;
      set;
    }
    public decimal GTIN_LAYER
    {
      get;
      set;
    }
    public decimal GTIN_LAYER_QTY
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
  }
}
