using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PROG_WRT_HIS", Schema = "dbo")]
  public partial class ProgWrtHi
  {
    public string USER_ID
    {
      get;
      set;
    }
    public string PROG_ID
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
    public string APPROVE_WRT
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
