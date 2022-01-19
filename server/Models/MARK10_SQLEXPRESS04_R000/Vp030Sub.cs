using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_P030SUB", Schema = "dbo")]
  public partial class Vp030Sub
  {
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
    public decimal SKU_ALO_QTY
    {
      get;
      set;
    }
    public string EXPIRE_DATE
    {
      get;
      set;
    }
    public string GR_DATE
    {
      get;
      set;
    }
  }
}
