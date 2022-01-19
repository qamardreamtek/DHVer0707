using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("SP_R050", Schema = "dbo")]
  public partial class SpR050
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
    public string GTIN_UNIT
    {
      get;
      set;
    }
    public string BATCH_NO
    {
      get;
      set;
    }
    public string LOC_NO
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public string SU_TYPE
    {
      get;
      set;
    }
    public decimal GTIN_MAX_QTY
    {
      get;
      set;
    }
    public decimal? GTIN_QTY
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FULL_IND
    {
      get;
      set;
    }
  }
}
