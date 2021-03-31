﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Nav prop
        public ICollection<UserRole> UserRoles { get; set; }
    }
}