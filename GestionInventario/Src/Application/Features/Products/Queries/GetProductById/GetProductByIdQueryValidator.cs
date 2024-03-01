using FluentValidation;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{Id} no puede estar en blanco")
                 .NotNull();
        }
    }
}
