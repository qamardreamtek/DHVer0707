using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PCK_MST_HIS", Schema = "dbo")]
  public partial class PckMstHi
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string PCK_NO
    {
      get;
      set;
    }
    public string PCK_TYPE
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
    public string CMD_DATE
    {
      get;
      set;
    }
    public string CMD_SNO
    {
      get;
      set;
    }
    public string STN_NO
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
