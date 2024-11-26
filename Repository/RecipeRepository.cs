using Amazon.DynamoDBv2.DataModel;
using comp306_group7_recipevault.Models;

namespace comp306_group7_recipevault.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IDynamoDBContext _context;

        public RecipeRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<Recipe>(conditions).GetRemainingAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(string id)
        {
            return await _context.LoadAsync<Recipe>(id);
        }

        public async Task CreateRecipeAsync(Recipe recipe)
        {
            recipe.RecipeId = Guid.NewGuid().ToString();
            await _context.SaveAsync(recipe);
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _context.SaveAsync(recipe);
        }

        public async Task DeleteRecipeAsync(string id)
        {
            await _context.DeleteAsync<Recipe>(id);
        }
    }
}
