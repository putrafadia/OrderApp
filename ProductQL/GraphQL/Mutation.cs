using ProductQL.Models;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using System;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProductQL.GraphQL
{
    public class Mutation
    {

        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Product> AddProductAsync(
            InputProduct input,
            [Service] ProductQLContext context)
        {
            var product = new Product
            {
                Name = input.Name,
                Stock = input.Stock,
                Price = input.Price,
                Created = DateTime.Now
            };

            var ret = context.Products.Add(product);
            await context.SaveChangesAsync();

            return ret.Entity;
        }
        public async Task<Product> GetProductByIdAsync(
            int id,
            [Service] ProductQLContext context)
        {
            var product = context.Products.Where(o => o.Id ==id).FirstOrDefault();

            return await Task.FromResult(product);
        }

        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Product> UpdateProductAsync(
            InputProduct input,
            [Service] ProductQLContext context)
        {
            var product = context.Products.Where(o => o.Id == input.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = input.Name;
                product.Stock = input.Stock;
                product.Price = input.Price;

                context.Products.Update(product);
                await context.SaveChangesAsync();
            }


            return await Task.FromResult(product);
        }
        [Authorize(Roles = new[] {"MANAGER"})]
        public async Task<Product> DeleteProductByIdAsync(
            int id,
            [Service] ProductQLContext context)
        {
            var product = context.Products.Where(o => o.Id == id).FirstOrDefault();
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }


            return await Task.FromResult(product);
        }

    }
}
