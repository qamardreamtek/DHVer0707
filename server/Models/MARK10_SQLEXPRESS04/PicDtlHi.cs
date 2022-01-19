using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PIC_DTL_HIS", Schema = "dbo")]
  public partial class PicDtlHi
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string PIC_NO
    {
      get;
      set;
    }
    public string PIC_LINE
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
    public string COUNT_USER
    {
      get;
      set;
    }
    public decimal? COUNT_QTY
    {
      get;
      set;
    }
    public string COUNT_UNIT
    {
      get;
      set;
    }
    public string WMSLOC_IND
    {
      get;
      set;
    }
    public string REASON1
    {
      get;
      set;
    }
    public string REASON2
    {
      get;
      set;
    }
    public string REASON3
    {
      get;
      set;
    }
    public string REASON4
    {
      get;
      set;
    }
    public string REASON5
    {
      get;
      set;
    }
    public string REASON6
    {
      get;
      set;
    }
    public string REASON7
    {
      get;
      set;
    }
    public string REASON8
    {
      get;
      set;
    }
    public string REASON9
    {
      get;
      set;
    }
    public string REASON10
    {
      get;
      set;
    }
    public string BATCH_IND
    {
      get;
      set;
    }
    public string SERIAL_IND
    {
      get;
      set;
    }
    public string START_DATE
    {
      get;
      set;
    }
    public string END_DATE
    {
      get;
      set;
    }
    public string PIC_STS
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
