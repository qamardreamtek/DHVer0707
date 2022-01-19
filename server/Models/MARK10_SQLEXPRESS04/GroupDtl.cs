using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("GROUP_DTL", Schema = "dbo")]
  public partial class GroupDtl
  {
    [Key]
    public string GROUP_ID
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
    public string USER_NAME
    {
      get;
      set;
    }
    public string DEPT_NAME
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
  }
}
