﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Belajar_Identity.Models
{
    public class UserRoleVM
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}