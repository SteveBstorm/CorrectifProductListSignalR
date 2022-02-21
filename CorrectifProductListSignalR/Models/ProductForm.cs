using System.ComponentModel.DataAnnotations;

namespace CorrectifProductListSignalR.Models
{
    public class ProductForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
