using comp306_group7_recipevault.Models;

namespace comp306_group7_recipevault.Repository
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        public Task<Recipe> GetRecipeByIdAsync(string id);
        public Task CreateRecipeAsync(Recipe recipe);
        public Task UpdateRecipeAsync(Recipe recipe);
        public Task DeleteRecipeAsync(string id);
    }
}
