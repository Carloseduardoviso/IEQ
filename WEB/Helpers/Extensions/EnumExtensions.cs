using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var member = enumValue.GetType()
                              .GetMember(enumValue.ToString())
                              .First();

        var displayAttr = member.GetCustomAttribute<DisplayAttribute>();

        return displayAttr?.Name ?? enumValue.ToString();
    }
}