// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ConvertToJSON;
//
//    var reslt = CustomVisionResult.FromJson(jsonString);

namespace ConvertToJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CustomVisionResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("iteration")]
        public string Iteration { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("predictions")]
        public List<Prediction> Predictions { get; set; }
    }

    public partial class Prediction
    {
        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("tagId")]
        public string TagId { get; set; }

        [JsonProperty("tagName")]
        public string TagName { get; set; }

        [JsonProperty("boundingBox")]
        public BoundingBox BoundingBox { get; set; }
    }

    public partial class BoundingBox
    {
        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("top")]
        public double Top { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }
    }

    public partial class CustomVisionResult
    {
        public static CustomVisionResult FromJson(string json) => JsonConvert.DeserializeObject<CustomVisionResult>(json, ConvertToJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CustomVisionResult self) => JsonConvert.SerializeObject(self, ConvertToJson.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
