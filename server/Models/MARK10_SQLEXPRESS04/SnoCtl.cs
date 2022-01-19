using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SNO_CTL", Schema = "dbo")]
  public partial class SnoCtl
  {
    [Key]
    public string SNO_TYPE
    {
      get;
      set;
    }
    public decimal SNO
    {
      get;
      set;
    }
    public string TRN_DATE
    {
      get;
      set;
    }
  }
}
