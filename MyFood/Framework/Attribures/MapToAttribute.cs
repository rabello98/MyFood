using System;

namespace MyFood.Framework.Attribures
{
    public sealed class MapToAttribute : Attribute
    {
        public Type Type { get; private set; }
        public MapToAttribute(Type type)
        {
            Type = type;
        }
    }
}
