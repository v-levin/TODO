using System;
using System.Linq;
using System.Reflection;

namespace ToDo.BLL.Extensions
{
    public static class Extensions
    {
        public static TAttribute GetEnumDescription<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
