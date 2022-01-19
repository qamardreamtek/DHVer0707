using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PCK_DTL", Schema = "dbo")]
  public partial class PckDtl
  {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string PCK_NO
    {
      get;
      set;
    }
    [Key]
    public string PCK_LINE
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public string SU_ID_TO
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
    public string GTIN_UNIT
    {
      get;
      set;
    }
    public decimal GTIN_ALO_QTY
    {
      get;
      set;
    }
    public decimal GTIN_FIN_QTY
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
    public decimal SKU_ALO_QTY
    {
      get;
      set;
    }
    public decimal SKU_FIN_QTY
    {
      get;
      set;
    }
    public string PCK_USER
    {
      get;
      set;
    }
    public string PCK_DATE
    {
      get;
      set;
    }
    public string PCK_STS
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
