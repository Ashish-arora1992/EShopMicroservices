using CatalogApi.Products.CreateProduct;
using CatalogApi.Products.GetProductById;
using Marten.Exceptions;

namespace CatalogApi.Products.UpdateProductById
{
    public record UpdateProductByIdCommand(Guid Id,string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<UpdateProductByIdResult>;
    
    public record UpdateProductByIdResult(bool IsSuccess);
    public class UpdateProductByIdHandler(IDocumentSession session) : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {


            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
                throw new Exception("Product not found");

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price += command.Price;
            try
            {
                session.Update(product);
                await session.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                // Handle concurrency conflict, e.g., retry or notify the user
                return new UpdateProductByIdResult(false);
            }

            return new UpdateProductByIdResult(true);
        }
    }
        
    
}
