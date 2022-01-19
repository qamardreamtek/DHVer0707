using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_C010", Schema = "dbo")]
  public partial class Vc010
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
    public string LOC_NO
    {
      get;
      set;
    }
    public string EQU_NO
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
    public string SKU_BATCH
    {
      get;
      set;
    }
    public string SKU_SNO_IND
    {
      get;
      set;
    }
    public string TRN_DATE
    {
      get;
      set;
    }
    public decimal GTIN_MAX_QTY
    {
      get;
      set;
    }
    public string COUNT_DATE
    {
      get;
      set;
    }
    public decimal? GTIN_QTY
    {
      get;
      set;
    }
    public decimal? SKU_QTY
    {
      get;
      set;
    }
    public decimal LOC_QTY
    {
      get;
      set;
    }
    public string GTIN_UNIT
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
  }
}
