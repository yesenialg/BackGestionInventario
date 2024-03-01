using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using GestionInventario.Api.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GestionInventario.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) : base() 
        {
            _mediator = mediator;
        }

        [HttpPost("Create", Name = "Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            return await HandleRequestAsync(async () => await _mediator.Send(command));
        }

        [HttpGet("GetAll", Name = "GetAll")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            return await HandleRequestAsync(async () => await _mediator.Send(query));
        }


        [HttpGet("GetById/{id}", Name = "GetById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetProductByIdQuery(id);
            return await HandleRequestAsync(async () => await _mediator.Send(query));
        }


        [HttpPut("Update", Name = "Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            return await HandleRequestAsync(async () => await _mediator.Send(command));
        }
    }
}