using System.Text.Json.Serialization;

namespace Catalog.Api.DTO
{
    public class ItemEditDto
    {

        [JsonPropertyName("name"), JsonRequired, JsonPropertyOrder(1)]
        public string Name { get; set; }

        [JsonPropertyName("description"), JsonRequired, JsonPropertyOrder(2)]
        public string Description { get; set; }
    }
}
