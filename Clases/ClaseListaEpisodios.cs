using System.Text.Json.Serialization;

namespace EspacioClaseListaEpisdios
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    public class Image
    {
        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("original")]
        public string Original { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("self")]
        public Self Self { get; set; }

        [JsonPropertyName("show")]
        public Show Show { get; set; }
    }

    public class Rating
    {
        [JsonPropertyName("average")]
        public double Average { get; set; }
    }

    public class Episodio
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("season")]
        public int Season { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("airdate")]
        public string Airdate { get; set; }

        [JsonPropertyName("airtime")]
        public string Airtime { get; set; }

        [JsonPropertyName("airstamp")]
        public DateTime Airstamp { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("rating")]
        public Rating Rating { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Self
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

    public class Show
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}