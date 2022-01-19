using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_P020B", Schema = "dbo")]
  public partial class Vp020B
  {
    public string stge_type
    {
      get;
      set;
    }
    public string stge_bin
    {
      get;
      set;
    }
    public string whse_no
    {
      get;
      set;
    }
    public string plant
    {
      get;
      set;
    }
    public string stge_loc
    {
      get;
      set;
    }
    public string sku_no
    {
      get;
      set;
    }
    public string batch_no
    {
      get;
      set;
    }
    public string stk_cat
    {
      get;
      set;
    }
    public string stk_special_ind
    {
      get;
      set;
    }
    public string stk_special_no
    {
      get;
      set;
    }
    public string gtin_unit
    {
      get;
      set;
    }
    public string sku_unit
    {
      get;
      set;
    }
    public string su_id
    {
      get;
      set;
    }
    public string su_type
    {
      get;
      set;
    }
    public string loc_no
    {
      get;
      set;
    }
    public decimal sku_qty
    {
      get;
      set;
    }
    public decimal sku_alo_qty
    {
      get;
      set;
    }
    public string EXPIRE_DATE
    {
      get;
      set;
    }
    public string GR_DATE
    {
      get;
      set;
    }
    public decimal? gtin_numerator
    {
      get;
      set;
    }
    public decimal? gtin_denominator
    {
      get;
      set;
    }
  }
}
