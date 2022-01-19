using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("v_user_role", Schema = "dbo")]
  public partial class VUserRole
  {
    public string UserId
    {
      get;
      set;
    }
    public string UserName
    {
      get;
      set;
    }
    public string RoleId
    {
      get;
      set;
    }
    public string RoleName
    {
      get;
      set;
    }
  }
}
