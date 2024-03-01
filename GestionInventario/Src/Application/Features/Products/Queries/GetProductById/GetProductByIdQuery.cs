using Core;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductCore>
    {
        public GetProductByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
