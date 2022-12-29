using Newtonsoft.Json;
using System.Reflection;

namespace MsBot.Vo.Plugins;

public class MsBotEnumConverter : JsonConverter
{
    public MsBotEnumConverter()
    {
    }
    public override bool CanConvert(Type objectType)
    {
        if(objectType == typeof(Enum))
            return true;

        return false;
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if(reader.TokenType == JsonToken.Null)
            return null;

        var values = Enum.GetValues(objectType);
        foreach(var v in values)
        {
            var field = objectType.GetField(v.ToString());
            if(field == null)
                continue;

            var property = field.GetCustomAttribute<JsonPropertyAttribute>();
            if(property != null)
            {
                if(property.PropertyName == reader.Value.ToString())
                    return v;
            }
            else
            {
                if(v.ToString().ToLower() == reader.Value.ToString())
                    return v;
            }
        }
        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if(value == null || string.IsNullOrEmpty(value.ToString()))
        {
            writer.WriteNull();
            return;
        }

        string bValue = GetEnumDescription(value.GetType(), value.ToString());
        writer.WriteValue(bValue);
    }

    /// <summary>
    /// 获取枚举描述
    /// </summary>
    /// <param name="type">枚举类型</param>
    /// <param name="value">枚举名称</param>
    /// <returns></returns>
    private string GetEnumDescription(Type type, string value)
    {
        try
        {
            FieldInfo field = type.GetField(value);
            if(field == null)
            {
                return "";
            }

            var desc = Attribute.GetCustomAttribute(field, typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
            if(desc != null)
                return desc.PropertyName;

            return "";
        }
        catch
        {
            return "";
        }
    }
}
