using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("CtrlHS", Schema = "dbo")]
  public partial class CtrlH
  {
    [Key]
    public string EquNo
    {
      get;
      set;
    }
    public string HS
    {
      get;
      set;
    }
    public string TrnDT
    {
      get;
      set;
    }
  }
}
