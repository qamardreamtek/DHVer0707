using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_R060", Schema = "dbo")]
  public partial class Vr060
  {
    public string SKU_NO
    {
      get;
      set;
    }
    public string SKU_DESC
    {
      get;
      set;
    }
    public int Outbound
    {
      get;
      set;
    }
    public int Inbound
    {
      get;
      set;
    }
    public int Relocation
    {
      get;
      set;
    }
    public int Total
    {
      get;
      set;
    }
  }
}
