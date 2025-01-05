


using FluentValidation;

namespace CatalogApi.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() { 

            RuleFor(c=>c.Name).NotEmpty().WithMessage("Name is mandatory");
           RuleFor(c => c.Category).NotEmpty().WithMessage("Category is mandatory");
        //    RuleFor(c => c.Description).NotEmpty().WithMessage("Description is mandatory");
          //  RuleFor(c => c.ImageFile).NotEmpty().WithMessage("ImageFile is mandatory");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        }

    }
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            
            var product = command.Adapt<Product>();
            //var product = new Product()
            //{
            //    Name=command.Name,
            //    Category=command.Category,
            //    Description=command.Description,
            //    ImageFile=command.ImageFile,    
            //    Price=command.Price,    
                                
            //};
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
