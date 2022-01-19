using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PIC_MST_HIS", Schema = "dbo")]
  public partial class PicMstHi
  {
    public string WHSE_NO
    {
      get;
      set;
    }
    public string PIC_NO
    {
      get;
      set;
    }
    public string PIC_GROUP
    {
      get;
      set;
    }
    public string PIC_TYPE
    {
      get;
      set;
    }
    public string PLANT
    {
      get;
      set;
    }
    public string STGE_LOC
    {
      get;
      set;
    }
    public string COUNT_USER
    {
      get;
      set;
    }
    public string SHELF
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
    public string PIC_STS
    {
      get;
      set;
    }
    public string REMARK
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
    public string LOG_DATE
    {
      get;
      set;
    }
    public string LOG_USER
    {
      get;
      set;
    }
  }
}
