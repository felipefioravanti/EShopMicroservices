using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    // represents the data we need to create in a new product
    public record CreateProductCommand(Guid GuidId,
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price)
     : ICommand<CreateProductResult>; // Represents de Request and Response Type in MediatR


    // represents the response of the created product
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a command

            // 1. create Product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            // 2. save to database
            // return result
            return new CreateProductResult(Guid.NewGuid());
            // return CreateProductResult as result
        }
    }
}