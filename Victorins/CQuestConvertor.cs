using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Victorins
{
    internal class CQuestConvertor : JsonConverter<CQuest>
    {
        public override CQuest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDoc = JsonDocument.ParseValue(ref reader);

            try
            {
                

                string type = jsonDoc.RootElement.GetProperty("$type").GetString();

                switch (type)
                {
                    case "CQuestAsk":
                        return JsonSerializer.Deserialize<CQuestAsk>(jsonDoc.RootElement.GetRawText(), options);
                    case "CQuest2Variants":
                        return JsonSerializer.Deserialize<CQuest2Variants>(jsonDoc.RootElement.GetRawText(), options);
                    default:
                        throw new NotSupportedException($"Unknown type: {type}");
                }
            }
            finally
            {
                jsonDoc.Dispose();
            }
        }

        public override void Write(Utf8JsonWriter writer, CQuest value, JsonSerializerOptions options)
        {
            string type = value.GetType().Name;

            string json = JsonSerializer.Serialize(value, value.GetType(), options);
            var jsonDoc = JsonDocument.Parse(json);

            try
            {
                writer.WriteStartObject();
                writer.WriteString("$type", type);

                foreach (var property in jsonDoc.RootElement.EnumerateObject())
                {
                    property.WriteTo(writer);
                }

                writer.WriteEndObject();
            }
            finally
            {
                jsonDoc.Dispose();
            }
        }
    }
}
