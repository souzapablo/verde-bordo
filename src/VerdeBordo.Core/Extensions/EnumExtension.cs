using System.ComponentModel;
using System.Reflection;

namespace VerdeBordo.Core.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? fi = value.GetType()
            .GetField(value.ToString());

        if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }
        
        return value.ToString();        
    }
}