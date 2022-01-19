using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("OUT_MST", Schema = "dbo")]
  public partial class OutMst
  {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string OUT_NO
    {
      get;
      set;
    }
    public string OUT_TYPE
    {
      get;
      set;
    }
    public string OUT_DATE
    {
      get;
      set;
    }
    public string OUT_TIME
    {
      get;
      set;
    }
    public string PLAN_DATE
    {
      get;
      set;
    }
    public string PICK_DATE
    {
      get;
      set;
    }
    public string PICK_TIME
    {
      get;
      set;
    }
    public string LOAD_DATE
    {
      get;
      set;
    }
    public string TP_DATE
    {
      get;
      set;
    }
    public string WHSE_DOOR
    {
      get;
      set;
    }
    public string SHIP_NO
    {
      get;
      set;
    }
    public string SHIP_LOC
    {
      get;
      set;
    }
    public string SHIP_TO
    {
      get;
      set;
    }
    public string SHIP_TO_NAME
    {
      get;
      set;
    }
    public string SHIP_CONDITION
    {
      get;
      set;
    }
    public string QUEUE
    {
      get;
      set;
    }
    public string CAR_LIC
    {
      get;
      set;
    }
    public decimal GROSS_WEIGHT
    {
      get;
      set;
    }
    public decimal NET_WEIGHT
    {
      get;
      set;
    }
    public string WEIGHT_UNIT
    {
      get;
      set;
    }
    public string DD_NO
    {
      get;
      set;
    }
    public string DOC_DATE
    {
      get;
      set;
    }
    public string CREATEUSER
    {
      get;
      set;
    }
    public string CREATEDATE
    {
      get;
      set;
    }
    public string CREATETIME
    {
      get;
      set;
    }
    public string OUT_STS
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
