using Microsoft.EntityFrameworkCore;
using SamBlazor.Data;
using SamBlazor.Repository.IRepoistory;

namespace SamBlazor.Repository
{
    public class ProductRepoistory : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductRepoistory(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            var imagepath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/'));
            if(File.Exists(imagepath))
            {
                File.Delete(imagepath);
            }
            if (product != null)
            {
                 _context.Products.Remove(product);
                return await(_context.SaveChangesAsync())>0;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
           return await _context.Products.Include(obj=>obj.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
               
                return new Product();
            }
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var selectedProduct =await _context.Products.FirstOrDefaultAsync(c => c.Id == product.Id);
            if (selectedProduct != null)
            {
                selectedProduct.Name = product.Name;
                selectedProduct.ImageUrl=product.ImageUrl;
                selectedProduct.Price = product.Price;
                selectedProduct.Description = product.Description;
                selectedProduct.SpecialTag = product.SpecialTag;
                _context.Products.Update(selectedProduct);
                await _context.SaveChangesAsync();
                return selectedProduct;
            }
            return new Product();
        }
    }
}
