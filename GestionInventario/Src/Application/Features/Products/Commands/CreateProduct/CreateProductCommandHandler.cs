using Application.Contracts.Infrastructure;
using AutoMapper;
using Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCore = _mapper.Map<ProductCore>(request);

            var newProduct = await _repository.CreateAsync(productCore);

            _logger.LogInformation($"El producto {newProduct.Id}: {newProduct.Name} fue creado");

            return newProduct.Id;
        }
    }
}
