
namespace Cartera_movil.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Cartera
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dinero")]
        public float Dinero { get; set; }
    }

    public partial class Cartera
    {
        public static List<Cartera> FromJson(string json) => JsonConvert.DeserializeObject<List<Cartera>>(json, Cartera_movil.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Cartera> self) => JsonConvert.SerializeObject(self, Cartera_movil.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

