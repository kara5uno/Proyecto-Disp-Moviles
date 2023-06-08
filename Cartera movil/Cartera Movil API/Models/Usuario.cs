
namespace Cartera_movil_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Usuario
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public partial class Usuario
    {
        public static List<Usuario> FromJson(string json) => JsonConvert.DeserializeObject<List<Usuario>>(json, Cartera_movil_API.Models.Converteru.Settings);
    }

    public static class Serializeu
    {
        public static string ToJson(this List<Usuario> self) => JsonConvert.SerializeObject(self, Cartera_movil_API.Models.Converteru.Settings);
    }

    internal static class Converteru
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
