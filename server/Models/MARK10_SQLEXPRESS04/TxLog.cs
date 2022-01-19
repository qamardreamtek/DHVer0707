using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("TX_LOG", Schema = "dbo")]
  public partial class TxLog
    {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string TX_NO
    {
      get;
      set;
    }
    [Key]
    public string TX_LINE
    {
      get;
      set;
    }
    public string STGE_TYPE
    {
      get;
      set;
    }
    public string STGE_TYPE_TO
    {
      get;
      set;
    }
    public string STGE_BIN
    {
      get;
      set;
    }
    public string STGE_BIN_TO
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
    public string TX_USER
    {
      get;
      set;
    }
    public string TX_DATE
    {
      get;
      set;
    }
    public string TX_STS
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
