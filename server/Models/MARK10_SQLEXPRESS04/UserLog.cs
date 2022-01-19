using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("USER_LOG", Schema = "dbo")]
  public partial class UserLog
  {
    [Key]
    public string LOG_DATE
    {
      get;
      set;
    }
    [Key]
    public string LOG_TYPE
    {
      get;
      set;
    }
    [Key]
    public string USER_ID
    {
      get;
      set;
    }
    [Key]
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
    public string REMARK
    {
      get;
      set;
    }
  }
}
