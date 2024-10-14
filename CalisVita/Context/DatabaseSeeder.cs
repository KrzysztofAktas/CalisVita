using System;
using System.Collections.Generic;
using System.Linq;
using CalisVita.Model;
using Microsoft.AspNetCore.Identity;

namespace CalisVita.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

       

        public DatabaseSeeder(DatabaseContext context, UserManager<User> usermanager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = usermanager;
            _roleManager = roleManager;

        }

       
    }



}


