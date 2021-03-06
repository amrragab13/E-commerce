﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Extentions
{
    public static class UserManagerExtentions
    {
        public static async Task<AppUser> FindByEmailWithAddressAsync(this UserManager<AppUser> input,
            ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
                     .Value;

            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailClaimsPrincipal(this UserManager<AppUser> input,
            ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
                         .Value;
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);

        }
    }
}
