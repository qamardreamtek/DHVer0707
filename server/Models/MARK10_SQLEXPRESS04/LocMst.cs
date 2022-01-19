using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("LOC_MST", Schema = "dbo")]
  public partial class LocMst
    {
    [Key]
    public string WHSE_NO
    {
      get;
      set;
    }
    [Key]
    public string LOC_NO
    {
      get;
      set;
    }
    public string LOC_NAME
    {
      get;
      set;
    }
    [Key]
    public string ZONE_NO
    {
      get;
      set;
    }
    public string LANE_NO
    {
      get;
      set;
    }
    public string EQU_NO
    {
      get;
      set;
    }
    public decimal ROW_X
    {
      get;
      set;
    }
    public decimal BAY_Y
    {
      get;
      set;
    }
    public decimal LVL_Z
    {
      get;
      set;
    }
    public string LOC_ASRS
    {
      get;
      set;
    }
    public string LOC_STS
    {
      get;
      set;
    }
    public string LOC_OSTS
    {
      get;
      set;
    }
    public decimal AVAIL
    {
      get;
      set;
    }
    public string DEPTH
    {
      get;
      set;
    }
    public string LOC_SIZE
    {
      get;
      set;
    }
    public string LOC_TYPE
    {
      get;
      set;
    }
    public string LOC_ABC
    {
      get;
      set;
    }
    public string LOC_SPECIAL
    {
      get;
      set;
    }
    public string LOC_HOT
    {
      get;
      set;
    }
    public string LOC_RCV
    {
      get;
      set;
    }
    public string LOC_STOCK
    {
      get;
      set;
    }
    public string LOC_QC
    {
      get;
      set;
    }
    public string LOC_NG
    {
      get;
      set;
    }
    public string LOC_RETURN
    {
      get;
      set;
    }
    public string LOC_SORT
    {
      get;
      set;
    }
    public string LOC_PICK
    {
      get;
      set;
    }
    public string LOC_STAGE
    {
      get;
      set;
    }
    public string LOC_DEL
    {
      get;
      set;
    }
    public string SU_ID
    {
      get;
      set;
    }
    public string COUNT_DATE
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
  }
}
