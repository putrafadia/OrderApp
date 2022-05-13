using OrderQL.Models;

namespace OrderQL.GraphQL
{
    public class Query
    {
       
        //[Authorize]
        //public IQueryable<Order> GetOrders([Service] ProductQLContext context, ClaimsPrincipal claimsPrincipal)
        //{
        //    var userName = claimsPrincipal.Identity.Name;

        //    // check manager role ?
        //    var managerRole = claimsPrincipal.Claims.Where(o => o.Type == ClaimTypes.Role).FirstOrDefault();
        //    var user = context.Users.Where(o => o.Username == userName).FirstOrDefault();
        //    if (user != null)
        //    {
        //        if (managerRole.Value == "MANAGER")
        //        {
        //                return context.Orders.Include(d=>d.OrderDetails);
        //        }
        //        var orders = context.Orders.Where(o => o.UserId == user.Id).Include(d=>d.OrderDetails);
        //        return orders.AsQueryable();
        //    }

        //    return new List<Order>().AsQueryable();
        //}

        public IQueryable<Order> GetOrders([Service] ProductQLContext context) =>
          context.Orders;

    }
}
