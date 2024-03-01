using Application.Contracts.Infrastructure;
using Core;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyCollection<ProductCore>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IReadOnlyCollection<ProductCore>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync();
        }
    }
}
