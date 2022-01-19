using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PC_LOG", Schema = "dbo")]
  public partial class PcLog
  {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string PC_NO
    {
      get;
      set;
    }
    [Key]
    public string PC_LINE
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
    public string MOVM_TYPE
    {
      get;
      set;
    }
    public string STK_CAT_TO
    {
      get;
      set;
    }
    public string STK_SPECIAL_IND_TO
    {
      get;
      set;
    }
    public string STK_SPECIAL_NO_TO
    {
      get;
      set;
    }
    public decimal SKU_QTY_TO
    {
      get;
      set;
    }
    public string PC_USER
    {
      get;
      set;
    }
    public string PC_DATE
    {
      get;
      set;
    }
    public string PC_STS
    {
      get;
      set;
    }
    public string REMARK
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
