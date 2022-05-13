using Microsoft.Extensions.Options;
using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;
using OrderQL.Models;
using Newtonsoft.Json;

namespace OrderQL.GraphQL
{
    public class Mutation
    {
        //Order
        [Authorize]
        public async Task<StatusOrder> AddOrderAsync(
            InputOrder input, ClaimsPrincipal claimsPrincipal,
            [Service] ProductQLContext context, [Service] IOptions<KafkaSettings> settings)
        {
            var dts = DateTime.Now.ToString();
            var key = "order-" + dts;
            var val = JsonConvert.SerializeObject(input);

            var result = await KafkaHelper.SendMessage(settings.Value, "apporder", key, val);

            StatusOrder resp = new StatusOrder
            {
                TransactionDate = dts,
                Message = "Order was submitted successfully"
            };

            if (!result)
                resp.Message = "Failed to submit data";

            return await Task.FromResult(resp);
        }

       

    }
}
