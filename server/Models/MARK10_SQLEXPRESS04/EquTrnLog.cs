using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquTrnLOG", Schema = "dbo")]
  public partial class EquTrnLog
  {
    [Key]
    public string TrnDT
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
    public string TrnUserID
    {
      get;
      set;
    }
    public string TrnDesc
    {
      get;
      set;
    }
  }
}
