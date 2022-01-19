using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadzenDh5.Models.Mark10Sqlexpress04
{
  [Table("PROG_MST", Schema = "dbo")]
  public partial class ProgMst
  {
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

        //public ICollection<Employee> Employees1 { get; set; }
        //public Employee Employee1 { get; set; }
        public ICollection<ProgMst> ProgMsts1 { get; set; }
        public ProgMst ProgMst1 { get; set; }
    }
}
