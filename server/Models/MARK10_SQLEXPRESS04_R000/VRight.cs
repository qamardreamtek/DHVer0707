using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_RIGHT", Schema = "dbo")]
  public partial class VRight
  {
    public string user_id
    {
      get;
      set;
    }
    public string PROG_ID
    {
      get;
      set;
    }
    public string PROG_NAME
    {
      get;
      set;
    }
    public string PROG_TYPE
    {
      get;
      set;
    }
    public string PARENT_ID
    {
      get;
      set;
    }
    public string PROG_NODE
    {
      get;
      set;
    }
    public string PROG_PATH
    {
      get;
      set;
    }
    public decimal PROG_SNO
    {
      get;
      set;
    }
    public string ENABLE
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
    public string TW_NAME
    {
      get;
      set;
    }
    public string CN_NAME
    {
      get;
      set;
    }
    public string TH_NAME
    {
      get;
      set;
    }
    public string VN_NAME
    {
      get;
      set;
    }
    public string UU
    {
      get;
      set;
    }
    public string QUERY_WRT
    {
      get;
      set;
    }
    public string PRINT_WRT
    {
      get;
      set;
    }
    public string IMPORT_WRT
    {
      get;
      set;
    }
    public string EXPORT_WRT
    {
      get;
      set;
    }
    public string UPDATE_WRT
    {
      get;
      set;
    }
    public string DELETE_WRT
    {
      get;
      set;
    }
    public string ARRROVE_WRT
    {
      get;
      set;
    }
  }
}
