using Core;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IReadOnlyCollection<ProductCore>>
    {
    }
}
