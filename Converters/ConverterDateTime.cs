using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiLancamentos.Converters
{
    public class ConverterDateTime : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), "yyyy/MM/dd", CultureInfo.CurrentCulture);
        }
    
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy/MM/dd"));
        }
    }
}