using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("TX_SNO", Schema = "dbo")]
  public partial class TxSno
  {
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
    [Key]
    public string IN_SNO
    {
      get;
      set;
    }
  }
}
