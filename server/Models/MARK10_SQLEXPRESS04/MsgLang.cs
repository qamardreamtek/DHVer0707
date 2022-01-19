using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("MSG_LANG", Schema = "dbo")]
  public partial class MsgLang
  {
    [Key]
    public string MSG_ID
    {
      get;
      set;
    }
    [Key]
    public string LANGUAGE
    {
      get;
      set;
    }
    public string MSG_DESC
    {
      get;
      set;
    }
  }
}
