using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace MyFood.Framework.Extensions
{
    public static class MapperExtensions
    {
        public static IMappingExpression IgnoreMaps(this IMappingExpression expression, Type initType, Type destType)
        {
            var props = destType.GetProperties().Where(p => p.GetCustomAttribute<Attribures.IgnoreMapAttribute>() != null);

            foreach (var prop in props)
            {
                expression.ForMember(prop.Name, config => config.Ignore());
            }
            return expression;
        }
    }
}
