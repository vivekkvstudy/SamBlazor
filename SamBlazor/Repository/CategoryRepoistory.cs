using Microsoft.EntityFrameworkCore;
using SamBlazor.Data;
using SamBlazor.Repository.IRepoistory;

namespace SamBlazor.Repository
{
    public class CategoryRepoistory : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepoistory(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                 _context.Categories.Remove(category);
                return await(_context.SaveChangesAsync())>0;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
               
                return new Category();
            }
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var selectedCategory =await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (selectedCategory != null)
            {
                selectedCategory.Name = category.Name;
                _context.Categories.Update(selectedCategory);
                await _context.SaveChangesAsync();
                return selectedCategory;
            }
            return new Category();
        }
    }
}
