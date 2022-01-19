using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class EntityTableInfo
    {
//        public string EntName { get; set; }
        public string Id { get; set; }
        public string EntName { get; set; }
        public string TblName { get; set; }

        public string EntColName { get; set; }
        public string TblColName { get; set; }

    }
}
