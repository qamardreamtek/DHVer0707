using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquCmdHis", Schema = "dbo")]
  public partial class EquCmdHi
  {
    [Key]
    public string HISDT
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
    public string CmdSts
    {
      get;
      set;
    }
    [Key]
    public string Source
    {
      get;
      set;
    }
    public string Destination
    {
      get;
      set;
    }
    public string LocSize
    {
      get;
      set;
    }
    public string Priority
    {
      get;
      set;
    }
    public string RCVDT
    {
      get;
      set;
    }
    public string ACTDT
    {
      get;
      set;
    }
    public string CSTPresenceDT
    {
      get;
      set;
    }
    public string ENDDT
    {
      get;
      set;
    }
    public string CompleteCode
    {
      get;
      set;
    }
    public string CompleteIndex
    {
      get;
      set;
    }
    public string CarNo
    {
      get;
      set;
    }
    public string ReNewFlag
    {
      get;
      set;
    }
    public string FromInfo
    {
      get;
      set;
    }
    public string PLT_ID
    {
      get;
      set;
    }
  }
}
