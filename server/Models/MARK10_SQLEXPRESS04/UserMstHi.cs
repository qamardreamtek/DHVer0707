using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("USER_MST_HIS", Schema = "dbo")]
  public partial class UserMstHi
  {
    public string USER_ID
    {
      get;
      set;
    }
    public string DEPT_NAME
    {
      get;
      set;
    }
    public string USER_NAME
    {
      get;
      set;
    }
    public string USER_PSWD
    {
      get;
      set;
    }
    public string TELPHONE
    {
      get;
      set;
    }
    public string MOBILE
    {
      get;
      set;
    }
    public string EMAIL
    {
      get;
      set;
    }
    public string LANGUAGE
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
    public string PSWD_DATE
    {
      get;
      set;
    }
    public string LAST_DATE
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
