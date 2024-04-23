namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductRequest(string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price);

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
            {
                // map the incoming request to create product command object
                var command = request.Adapt<CreateProductCommand>();

                // send object through mediator
                var result = await sender.Send(command);

                // map back the result
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}