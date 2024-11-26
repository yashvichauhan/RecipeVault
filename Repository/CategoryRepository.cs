using Amazon.DynamoDBv2.DataModel;
using comp306_group7_recipevault.Models;

namespace comp306_group7_recipevault.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDynamoDBContext _context;

        public CategoryRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Category>(conditions).GetRemainingAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            return await _context.LoadAsync<Category>(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.SaveAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _context.SaveAsync(category);
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _context.DeleteAsync<Category>(categoryId);
        }
    }
}
