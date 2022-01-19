using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("RPT_R030", Schema = "dbo")]
  public partial class RptR030
  {
    public string TRN_DATE
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
    public string DATE_CODE
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
    public string IN_SNO
    {
      get;
      set;
    }
    public decimal? RCV_QTY
    {
      get;
      set;
    }
    public string SKU_UNIT
    {
      get;
      set;
    }
  }
}
