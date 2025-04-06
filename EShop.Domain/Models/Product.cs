using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Name { get; set; } = default!;
        public string Ean { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string Sku { get; set; } = default!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

    }

}
