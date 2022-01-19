using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("CMD_MST_HIS", Schema = "dbo")]
  public partial class CmdMstHi
  {
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
    public string CMD_STS
    {
      get;
      set;
    }
    public string EQU_NO
    {
      get;
      set;
    }
    public string PRTY
    {
      get;
      set;
    }
    public string STN_NO
    {
      get;
      set;
    }
    public string CMD_MODE
    {
      get;
      set;
    }
    public string IO_TYPE
    {
      get;
      set;
    }
    public string LOC_NO
    {
      get;
      set;
    }
    public string NEW_LOC
    {
      get;
      set;
    }
    public string TRACE
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public string CRT_DTE
    {
      get;
      set;
    }
    public string EXP_DTE
    {
      get;
      set;
    }
    public string END_DTE
    {
      get;
      set;
    }
    public string FIN_DTE
    {
      get;
      set;
    }
    public string COMPLETECODE
    {
      get;
      set;
    }
    public string REQM_NO
    {
      get;
      set;
    }
    public string REQM_LINE
    {
      get;
      set;
    }
    public string REF_NO
    {
      get;
      set;
    }
    public string REF_LINE
    {
      get;
      set;
    }
    public string PROG_ID
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
