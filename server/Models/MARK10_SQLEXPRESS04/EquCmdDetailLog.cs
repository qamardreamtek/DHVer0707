using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquCmdDetailLog", Schema = "dbo")]
  public partial class EquCmdDetailLog
  {
    [Key]
    public string LogDT
    {
      get;
      set;
    }
    [Key]
    public string CmdSno
    {
      get;
      set;
    }
    [Key]
    public string EquNo
    {
      get;
      set;
    }
    [Key]
    public string CmdMode
    {
      get;
      set;
    }
    public string FBank
    {
      get;
      set;
    }
    public string FBayLevel
    {
      get;
      set;
    }
    public string TBank
    {
      get;
      set;
    }
    public string TBayLevel
    {
      get;
      set;
    }
    public string TransferInfo
    {
      get;
      set;
    }
    public string WriteBuffer
    {
      get;
      set;
    }
    public string WritePLC
    {
      get;
      set;
    }
    public string StartAction
    {
      get;
      set;
    }
    public string Cycle1
    {
      get;
      set;
    }
    public string Fork1
    {
      get;
      set;
    }
    public string LoadPresence_On
    {
      get;
      set;
    }
    public string CSTPresence_On
    {
      get;
      set;
    }
    public string Cycle2
    {
      get;
      set;
    }
    public string Fork2
    {
      get;
      set;
    }
    public string LoadPresence_Off
    {
      get;
      set;
    }
    public string CSTPresence_Off
    {
      get;
      set;
    }
    public string CmdFinish
    {
      get;
      set;
    }
    public string CompleteCode
    {
      get;
      set;
    }
    public string PLCTimerCount
    {
      get;
      set;
    }
    public string Notes
    {
      get;
      set;
    }
  }
}
