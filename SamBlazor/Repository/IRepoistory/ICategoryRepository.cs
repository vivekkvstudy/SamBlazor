using SamBlazor.Data;

namespace SamBlazor.Repository.IRepoistory
{
    public interface ICategoryRepository
    {
         public Task<IEnumerable<Category>> GetAllCategoryAsync();

         public Task<Category> GetCategoryByIdAsync(int id);

         public Task<Category> CreateAsync(Category category);
         public Task<Category> UpdateAsync(Category category);

         public Task<bool> DeleteAsync(int id);


    }
}
