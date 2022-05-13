using ProductQL.Models;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductQL.GraphQL
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] ProductQLContext context) =>
            context.Products;


    }
}
