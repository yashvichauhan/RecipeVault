namespace comp306_group7_recipevault.Models
{
    public class RecipeDetailDTO
    {
        public string RecipeId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } // Points to an S3 bucket
        public string Instructions { get; set; }
        public string CategoryId { get; set; }
        public int CookingTime { get; set; }
        public List<string> Ingredients { get; set; } // List of ingredients
    }
}
