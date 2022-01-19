using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("V_USER_PROG_BY_GROUP", Schema = "dbo")]
  public partial class VUserProgByGroup
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
    public string GROUP_ID
    {
      get;
      set;
    }
    public string GROUP_WRT_ENABLE
    {
      get;
      set;
    }
  }
}
