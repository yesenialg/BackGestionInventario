using Application.Contracts.Infrastructure;
using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Core;
using MediatR;
using Microsoft.Extensions.Logging;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductCore>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductCore> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var existProduct = await _repository.GetAsync(request.Id);

            if (existProduct == null)
            {
                throw new ApplicationException($"No se encontró el producto {request.Id}");
            }

            var productCore = _mapper.Map<ProductCore>(request);

            await _repository.UpdateAsync(productCore);

            _logger.LogInformation($"El producto {request.Id} fue actualizado");

            return productCore;
        }
    }
}
