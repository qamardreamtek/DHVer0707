using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("v_table_list", Schema = "dbo")]
  public partial class VTableList
  {
    public string TABLE_CATALOG
    {
      get;
      set;
    }
    public string TABLE_SCHEMA
    {
      get;
      set;
    }
    public string TABLE_NAME
    {
      get;
      set;
    }
    public string TABLE_TYPE
    {
      get;
      set;
    }
  }
}
