using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_R080", Schema = "dbo")]
  public partial class Vr080
  {
    public string PIC_NO
    {
      get;
      set;
    }
    public string PIC_STS
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
    public string BATCH_NO
    {
      get;
      set;
    }
    public string COUNT_UNIT
    {
      get;
      set;
    }
    public decimal? GTIN_QTY
    {
      get;
      set;
    }
    public decimal? COUNT_QTY
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public decimal? DIFF_QTY
    {
      get;
      set;
    }
    public string COUNT_USER
    {
      get;
      set;
    }
    public string APPROVE_USER
    {
      get;
      set;
    }
  }
}
