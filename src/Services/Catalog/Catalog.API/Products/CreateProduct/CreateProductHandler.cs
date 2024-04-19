using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(Guid GuidId,
                                       string Name,
                                       List<string> Category,
                                       string Description,
                                       string ImageFile,
                                       decimal Price);

    public record CreateProductResult(Guid Id);
    public class CreateProductHandler
    {

    }
}