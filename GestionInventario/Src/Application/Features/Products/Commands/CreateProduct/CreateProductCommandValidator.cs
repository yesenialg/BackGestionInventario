using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} no puede exceder los 50 caracteres");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} no puede estar en blanco")
                .NotNull()
                .MaximumLength(200).WithMessage("{Description} no puede exceder los 200 caracteres");

            RuleFor(p => p.Price)
                 .NotEmpty().WithMessage("{Price} no puede estar en blanco")
                 .NotNull();

            RuleFor(p => p.Stock)
                 .NotEmpty().WithMessage("{Stock} no puede estar en blanco")
                 .NotNull();

        }
    }
}
