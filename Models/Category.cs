using Amazon.DynamoDBv2.DataModel;

namespace comp306_group7_recipevault.Models
{
    [DynamoDBTable("Category")]
    public class Category
    {
        [DynamoDBHashKey]
        public string CategoryId { get; set; }

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }

        [DynamoDBProperty]
        public long CreatedAt { get; set; }

        [DynamoDBProperty]
        public List<string> Cuisine { get; set; }
    }
}
