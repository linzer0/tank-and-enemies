using System;
using System.Collections.Generic;

namespace TankGame
{
    public class EnumPair
    {
        private Type Type { get; }
        private int Value { get; }

        public EnumPair(Type type, int value)
        {
            Type = type;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is not EnumPair other)
            {
                return false;
            }

            return Type == other.Type && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Value);
        }
    }

    public class EnumEqualityComparer : IEqualityComparer<EnumPair>
    {
        public bool Equals(EnumPair x, EnumPair y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(EnumPair obj)
        {
            return obj.GetHashCode();
        }
    }
}