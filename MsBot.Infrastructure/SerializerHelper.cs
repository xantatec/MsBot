using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace MsBot.Infrastructure;

/// <summary>
/// Serializer helper
/// </summary>
public class SerializerHelper
{
    private static SerializerHelper _instance;

    private SerializerHelper()
    {
    }

    /// <summary>
    /// 实例
    /// </summary>
    public static SerializerHelper Instance => _instance ??= new SerializerHelper();

    #region XML

    /// <summary>
    /// 序列化对象至文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="target">对象</param>
    public void XmlSerializeToFile(string filePath, object target)
    {
        XmlSerializeToFile(filePath, target, Encoding.UTF8);
    }

    /// <summary>
    /// 序列化对象至文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="target">对象</param>
    /// <param name="encoding">编码</param>
    public void XmlSerializeToFile(string filePath, object target, Encoding encoding)
    {
        var targetType = target.GetType();
        var xmlSerializer = new XmlSerializer(targetType);
        using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        xmlSerializer.Serialize(fs, target);
    }

    /// <summary>
    /// 序列化对象
    /// </summary>
    /// <param name="target">对象</param>
    public string XmlSerialize(object target)
    {
        return XmlSerialize(target, Encoding.UTF8);
    }

    /// <summary>
    /// 序列化对象
    /// </summary>
    /// <param name="target">对象</param>
    /// <param name="encoding">编码</param>
    public string XmlSerialize(object target, Encoding encoding)
    {
        var serializer = new XmlSerializer(target.GetType());
        var writer = new StringWriter(CultureInfo.InvariantCulture);
        serializer.Serialize(writer, target);

        var xml = writer.ToString();
        writer.Close();
        writer.Dispose();
        return xml;
    }

    /// <summary>
    /// 反序列化文件
    /// </summary>
    /// <typeparam name="TTarget">目标类型</typeparam>
    /// <param name="filePath">文件路径</param>
    public TTarget XmlDeserializeFromFile<TTarget>(string filePath) where TTarget : class
    {
        return XmlDeserializeFromFile<TTarget>(filePath, Encoding.UTF8);
    }

    /// <summary>
    /// 反序列化文件
    /// </summary>
    /// <typeparam name="TTarget">目标类型</typeparam>
    /// <param name="filePath">文件路径</param>
    /// <param name="encoding">编码</param>
    public TTarget XmlDeserializeFromFile<TTarget>(string filePath, Encoding encoding) where TTarget : class
    {
        return XmlDeserializeFromFile(filePath, encoding, typeof(TTarget)) as TTarget;
    }

    /// <summary>
    /// 反序列化文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="targetType">目标类型</param>
    public object XmlDeserializeFromFile(string filePath, Type targetType)
    {
        return XmlDeserializeFromFile(filePath, Encoding.UTF8, targetType);
    }

    /// <summary>
    /// 反序列化文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="encoding">编码</param>
    /// <param name="targetType">目标类型</param>
    public object XmlDeserializeFromFile(string filePath, Encoding encoding, Type targetType)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var xmlSerializer = new XmlSerializer(targetType);
        return xmlSerializer.Deserialize(fs);
    }

    /// <summary>
    /// 反序列化XML字符串
    /// </summary>
    /// <typeparam name="TTarget">目标类型</typeparam>
    /// <param name="xmlStr">XML字符串</param>
    public TTarget XmlDeserialize<TTarget>(string xmlStr) where TTarget : class
    {
        return XmlDeserialize<TTarget>(xmlStr, Encoding.UTF8);
    }

    /// <summary>
    /// 反序列化XML字符串
    /// </summary>
    /// <typeparam name="TTarget">目标类型</typeparam>
    /// <param name="xmlStr">XML字符串</param>
    /// <param name="encoding">编码</param>
    public TTarget XmlDeserialize<TTarget>(string xmlStr, Encoding encoding) where TTarget : class
    {
        return XmlDeserialize(xmlStr, encoding, typeof(TTarget)) as TTarget;
    }

    /// <summary>
    /// 反序列化XML字符串
    /// </summary>
    /// <param name="xmlStr">XML字符串</param>
    /// <param name="targetType">目标类型</param>
    public object XmlDeserialize(string xmlStr, Type targetType)
    {
        return XmlDeserialize(xmlStr, Encoding.UTF8, targetType);
    }

    /// <summary>
    /// 反序列化XML字符串
    /// </summary>
    /// <param name="xmlStr">XML字符串</param>
    /// <param name="encoding">编码</param>
    /// <param name="targetType">目标类型</param>
    public object XmlDeserialize(string xmlStr, Encoding encoding, Type targetType)
    {
        var buffer = encoding.GetBytes(xmlStr);
        var xmlSerializer = new XmlSerializer(targetType);
        var ms = new MemoryStream(buffer);
        return xmlSerializer.Deserialize(ms);
    }

    #endregion

    #region JSON

    /// <summary>
    /// Serialize target to Json string
    /// </summary>
    /// <param name="target">The target.</param>
    public string JsonSerialize(object target)
    {
        return JsonConvert.SerializeObject(target);
    }

    /// <summary>
    /// Deserialize json string to a TTarget type
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public TTarget JsonDeserialize<TTarget>(string jsonStr)
    {
        return JsonConvert.DeserializeObject<TTarget>(jsonStr);
    }

    /// <summary>
    /// Deserialize json from file.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    /// <param name="filePath">The file path.</param>
    public TTarget JsonDeserializeFromFile<TTarget>(string filePath) where TTarget : class
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        var jsonStr = File.ReadAllText(filePath);
        return JsonDeserialize<TTarget>(jsonStr);
    }

    #endregion
}