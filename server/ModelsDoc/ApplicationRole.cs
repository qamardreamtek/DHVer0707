﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string GroupName { get; set; }
    }
}
