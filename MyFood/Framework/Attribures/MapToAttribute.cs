using System;

namespace MyFood.Framework.Attribures
{
    public class MapToAttribute : Attribute
    {
        public Type Type { get; private set; }
        public MapToAttribute(Type type)
        {
            Type = type;
        }
    }
}
