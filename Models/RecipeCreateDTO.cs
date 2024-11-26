namespace comp306_group7_recipevault.Models
{
    public class RecipeCreateDTO
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; } // Must include S3 bucket URL
        public string Instructions { get; set; }
        public string CategoryId { get; set; }
        public int CookingTime { get; set; }
        public List<string> Ingredients { get; set; } // Ingredients list
    }
}
