using CorrectifProductListSignalR.Models;

namespace CorrectifProductListSignalR.Data
{
    public class ProductService
    {
        public List<Product> ProductList { get; set; }

        public ProductService()
        {
            ProductList = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            p.Id = GetId();
            ProductList.Add(p);
        }

        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(ProductList);
        }

        private int GetId()
        {
            if (ProductList.Count() >= 1)
                return ProductList.Max(x => x.Id) + 1;
            return 1;
        }
    }
}
