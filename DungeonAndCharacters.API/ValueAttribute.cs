using System;

namespace DungeonAndCharacters.API
{
    /// <summary>
    /// The value attribute binds a value to an enum and allows later retrieving.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ValueAttribute : Attribute
    {
        private readonly object _value;

        /// <summary>
        /// The default constructor which sets the bound value to the enum.
        /// </summary>
        /// <param name="value">The value which should be bound</param>
        public ValueAttribute(object value)
        {
            _value = value;
        }

        internal T As<T>()
        {
            if (_value is T t)
                return t;
            return default;
        }
    }
}