using System.Reflection.Emit;
using System.Reflection;

namespace MsBot.Infrastructure;

/// <summary>
/// 实体辅助
/// </summary>
public class ObjectHelper
{
    private static ObjectHelper _instance;

    private ObjectHelper()
    {
    }

    /// <summary>
    /// 实例
    /// </summary>
    public static ObjectHelper Instance => _instance ??= new ObjectHelper();

    /// <summary>
    /// 获取对象属性及值
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Dictionary<string, string> GetDynamicObjectValues(object obj)
    {
        var type = obj.GetType();
        var props = type.GetProperties();
        var dict = new Dictionary<string, string>();
        foreach (var prop in props)
        {
            var propGetMethod = EmitGetter(type, obj, prop);
            var v = propGetMethod();
            dict.Add(prop.Name, v?.ToString());
        }

        return dict;
    }

    /// <summary>
    /// Emit获取对象的属性值
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    private static Func<object> EmitGetter(Type type, object obj, PropertyInfo property)
    {
        var dynamicMethod = new DynamicMethod("get_" + property.Name, typeof(object), new[] { type }, type);
        var iLGenerator = dynamicMethod.GetILGenerator();
        iLGenerator.Emit(OpCodes.Ldarg_0);
        iLGenerator.Emit(OpCodes.Callvirt, property.GetMethod);
        iLGenerator.Emit(property.PropertyType.IsValueType ? OpCodes.Box : OpCodes.Castclass,
            property.PropertyType);
        iLGenerator.Emit(OpCodes.Ret);
        return dynamicMethod.CreateDelegate(typeof(Func<object>), obj) as Func<object>;
    }
}