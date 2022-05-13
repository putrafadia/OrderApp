using OrderQL.Models;
using System.Collections.Generic;

namespace OrderQL.GraphQL
{
    public record InputOrder
    (
        string Code,
        int UserId
        //List<OrderDetail> OrderDetails

    );
}
