using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("Cnt", Schema = "dbo")]
  public partial class CntResult
  {
    public int Cnt
    {
      get;
      set;
    }
  }
}
