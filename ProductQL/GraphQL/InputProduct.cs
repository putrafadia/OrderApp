namespace ProductQL.GraphQL
{
    public record InputProduct
    (
        int? Id,
        string Name,
        int Stock,
        double Price
    );
}
