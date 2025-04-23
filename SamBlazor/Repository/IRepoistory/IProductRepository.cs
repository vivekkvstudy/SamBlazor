using SamBlazor.Data;

namespace SamBlazor.Repository.IRepoistory
{
    public interface IProductRepository
    {
         public Task<IEnumerable<Product>> GetAllProductAsync();

         public Task<Product> GetProductByIdAsync(int id);

         public Task<Product> CreateAsync(Product product);
         public Task<Product> UpdateAsync(Product product);

         public Task<bool> DeleteAsync(int id);


    }
}
