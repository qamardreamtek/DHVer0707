using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp1
{
    public class ProgramBase
    {
        public string Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string NameZh { get; set; }
        public string NameTh { get; set; }
    }
}
