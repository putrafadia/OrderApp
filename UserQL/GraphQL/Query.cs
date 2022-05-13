using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserQL.Models;

namespace UserQL.GraphQL
{
    public class Query
    {
       
        [Authorize]
        public IQueryable<User> GetUsers([Service] ProductQLContext context, ClaimsPrincipal claimsPrincipal)
        {
            var adminRole = claimsPrincipal.Claims.Where(o => o.Type == ClaimTypes.Role).FirstOrDefault();
            var user = context.Users;
            if (user != null)
            {
                if (adminRole.Value == "ADMIN")
                {
                    return context.Users;
                }
            }

            return new List<User>().AsQueryable();
        }
        
    }
}
