using Application.Contracts.Infrastructure;
using Application.Features.Products.Queries.GetAllProducts;
using Core;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductCore>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ProductCore> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetAsync(request.Id);
        }
    }
}
