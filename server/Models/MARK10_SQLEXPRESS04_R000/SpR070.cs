using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SP_R070", Schema = "dbo")]
  public partial class SpR070
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
    public decimal? Outbound
    {
      get;
      set;
    }
    public decimal? Inbound
    {
      get;
      set;
    }
    public decimal? Relocation
    {
      get;
      set;
    }
    public decimal? Total
    {
      get;
      set;
    }
  }
}
