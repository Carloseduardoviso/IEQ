using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayNames<T>(this IEnumerable<T> enums)
    where T : Enum
    {
        return string.Join(", ", enums.Select(e => e.GetDisplayName()));
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        if (enumValue == null)
            return "";

        var member = enumValue.GetType()
                              .GetMember(enumValue.ToString())
                              .FirstOrDefault();

        if (member == null)
            return enumValue.ToString();

        var displayAttr = member.GetCustomAttribute<DisplayAttribute>();

        return displayAttr?.Name ?? enumValue.ToString();
    }
}