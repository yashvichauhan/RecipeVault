namespace comp306_group7_recipevault.Models
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedAt { get; set; }
        public List<string> Cuisine { get; set; }
    }
}
