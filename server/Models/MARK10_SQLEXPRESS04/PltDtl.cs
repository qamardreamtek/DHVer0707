using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PLT_DTL", Schema = "dbo")]
  public partial class PltDtl
  {
    [Key]
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
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string IN_NO
    {
      get;
      set;
    }
    [Key]
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
    [Key]
    public string STK_CAT
    {
      get;
      set;
    }
    [Key]
    public string STK_SPECIAL_IND
    {
      get;
      set;
    }
    [Key]
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
  }
}
