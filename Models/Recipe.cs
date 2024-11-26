using Amazon.DynamoDBv2.DataModel;

namespace comp306_group7_recipevault.Models
{
    [DynamoDBTable("Recipes")]
    public class Recipe
    {
        [DynamoDBHashKey]
        public string RecipeId { get; set; }
        
        [DynamoDBProperty]
        public string Name { get; set; }
        
        [DynamoDBProperty]
        public string ImageUrl {  get; set; }
        
        [DynamoDBProperty]
        public string Instructions { get; set; }
        
        [DynamoDBProperty]
        public string CategoryId { get; set; }
        
        [DynamoDBProperty]
        public int CookingTime { get; set; }
        
        [DynamoDBProperty]
        public List<string> Ingredients { get; set; }
    }
}
