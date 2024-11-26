namespace comp306_group7_recipevault.Models
{
    public class CategoryDetailDTO
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Cuisine { get; set; }
    }
}
