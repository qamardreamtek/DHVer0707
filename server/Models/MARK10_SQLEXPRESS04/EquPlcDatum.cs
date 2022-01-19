using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("EquPlcData", Schema = "dbo")]
  public partial class EquPlcDatum
  {
    [Key]
    public string EquNo
    {
      get;
      set;
    }
    [Key]
    public string SerialNo
    {
      get;
      set;
    }
    public string EquType
    {
      get;
      set;
    }
    public string EquPlcData
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
