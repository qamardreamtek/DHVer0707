using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SP_R040", Schema = "dbo")]
  public partial class SpR040
  {
    public string DATE
    {
      get;
      set;
    }
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
    public string EXPIRE_DATE
    {
      get;
      set;
    }
    public string BATCH_NO
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string IN_SNO
    {
      get;
      set;
    }
    public string GTIN_UNIT
    {
      get;
      set;
    }
    public decimal? GTIN_QTY
    {
      get;
      set;
    }
  }
}
