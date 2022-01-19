using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_P020A", Schema = "dbo")]
  public partial class Vp020A
  {
    public string WHSE_NO
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
    public string SKU_UNIT
    {
      get;
      set;
    }
    public decimal? SKU_CMD_QTY
    {
      get;
      set;
    }
  }
}
