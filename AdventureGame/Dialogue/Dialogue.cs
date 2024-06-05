namespace AdventureGame.Dialogue
{
        using System.Collections.Generic;
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class DialogueList
        {
            [JsonProperty("Dialogues", NullValueHandling = NullValueHandling.Ignore)]
            public List<DialogueElement> Dialogues { get; set; }

            [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }
        }

        public partial class DialogueElement
        {
            [JsonProperty("Nodes", NullValueHandling = NullValueHandling.Ignore)]
            public List<Node> Nodes { get; set; }
        }

        public partial class Node
        {
            [JsonProperty("Options", NullValueHandling = NullValueHandling.Ignore)]
            public List<Option> Options { get; set; }

            [JsonProperty("NodeID", NullValueHandling = NullValueHandling.Ignore)]
            public int NodeId { get; set; }

            [JsonProperty("Text", NullValueHandling = NullValueHandling.Ignore)]
            public string Text { get; set; }

            [JsonProperty("HasMethod", NullValueHandling = NullValueHandling.Ignore)]
            public bool HasMethod { get; set; }

            [JsonProperty("Method")]
            public string Method { get; set; }

            [JsonProperty("Params")]
            public List<string> Params { get; set; }
        }

        public partial class Option
        {
            [JsonProperty("Text", NullValueHandling = NullValueHandling.Ignore)]
            public string Text { get; set; }

            [JsonProperty("DestinationNodeID", NullValueHandling = NullValueHandling.Ignore)]
            public int DestinationNodeId { get; set; }
        }

        public partial class Dialogue
        {
            public static Dictionary<string, DialogueList> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, DialogueList>>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Dialogue self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new()
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