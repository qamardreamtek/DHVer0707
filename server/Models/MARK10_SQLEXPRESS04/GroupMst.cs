using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("GROUP_MST", Schema = "dbo")]
  public partial class GroupMst
  {
    [Key]
    public string GROUP_ID
    {
      get;
      set;
    }
    public string GROUP_NAME
    {
      get;
      set;
    }
    public string OWNER_ID
    {
      get;
      set;
    }
    public string OWNER_NAME
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
