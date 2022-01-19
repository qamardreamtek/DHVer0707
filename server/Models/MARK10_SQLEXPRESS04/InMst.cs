using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("IN_MST", Schema = "dbo")]
  public partial class InMst
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string IN_NO
    {
      get;
      set;
    }
    public string HEADER_STS
    {
      get;
      set;
    }
    public string SHIP_TYPE
    {
      get;
      set;
    }
    public decimal PRIORITY
    {
      get;
      set;
    }
    public string HEADER_TEXT
    {
      get;
      set;
    }
    public string REQM_NO
    {
      get;
      set;
    }
    public string REQM_TYPE
    {
      get;
      set;
    }
    public string MOVM_TYPE
    {
      get;
      set;
    }
    public string STGE_TYPE_FROM
    {
      get;
      set;
    }
    public string STGE_BIN_FROM
    {
      get;
      set;
    }
    public string DYNAMIC_IND_FROM
    {
      get;
      set;
    }
    public string STGE_TYPE_TO
    {
      get;
      set;
    }
    public string STGE_BIN_TO
    {
      get;
      set;
    }
    public string DYNAMIC_IND_TO
    {
      get;
      set;
    }
    public string PLAN_DATE
    {
      get;
      set;
    }
    public string TRN_NO
    {
      get;
      set;
    }
    public string TRN_YEAR
    {
      get;
      set;
    }
    public decimal? ITEM_COUNT
    {
      get;
      set;
    }
    public decimal? GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal? NET_WEIGHT
    {
      get;
      set;
    }
    public string WEIGHT_UNIT
    {
      get;
      set;
    }
    public decimal? VOLUME
    {
      get;
      set;
    }
    public string VOLUME_UNIT
    {
      get;
      set;
    }
    public string IN_STS
    {
      get;
      set;
    }
    public string SOURCE
    {
      get;
      set;
    }
    public string APPROVE_IND
    {
      get;
      set;
    }
    public string REMARK
    {
      get;
      set;
    }
    public string TRN_USER
    {
      get;
      set;
    }
    public string TRN_DATE
    {
      get;
      set;
    }
    public string CRT_USER
    {
      get;
      set;
    }
    public string CRT_DATE
    {
      get;
      set;
    }
  }
}
