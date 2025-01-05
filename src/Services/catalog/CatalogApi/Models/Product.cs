using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }= default! ;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default! ;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

        public Guid? mt_version { get; set; }
        public Guid Version { get; set; }

    }
}
