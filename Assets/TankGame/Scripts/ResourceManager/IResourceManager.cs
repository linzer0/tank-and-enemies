using System;
using UnityEngine;

namespace TankGame
{
    public interface IResourceManager
    {
        public GameObject GetFromPool<TEnum>(TEnum resource) where TEnum : struct, IComparable, IConvertible, IFormattable;
    }
}