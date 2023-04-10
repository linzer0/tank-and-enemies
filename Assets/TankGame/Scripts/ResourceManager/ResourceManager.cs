using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TankGame
{
    public class ResourceManager : IResourceManager
    {
        private List<PoolItem> _pool;
        private Dictionary<EnumPair, Object> _resourceCache;

        private class PoolItem
        {
            public Type EnumType;
            public int EnumValue;

            public GameObject GameObject;
            public object Component;
        }

        public ResourceManager()
        {
            _pool = new List<PoolItem>();
            _resourceCache = new Dictionary<EnumPair, Object>(new EnumEqualityComparer());
        }

        public GameObject GetFromPool<TEnum>(TEnum resource) where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);
            int value = resource.GetHashCode();

            foreach (var item in _pool)
            {
                if (item.EnumType == type && item.EnumValue == value && item.GameObject.activeSelf == false)
                {
                    item.GameObject.transform.parent = null;
                    item.GameObject.SetActive(true);
                    return item.GameObject;
                }
            }

            var name = resource.ToString();
            
            var poolItem = new PoolItem
            {
                EnumType = type,
                EnumValue = value,
                GameObject = Instantiate(type, value, name)
            };

            _pool.Add(poolItem);

            return poolItem.GameObject;
        }

        private GameObject Instantiate(Type type, int value, string name)
        {
            var assets = GetAsset(type, value, name);
            var instance = Object.Instantiate(assets) as GameObject;
            instance.SetActive(true);

            return instance;
        }

        private Object GetAsset(Type type, int value, string name)
        {
            var enumTypeValue = new EnumPair(type, value);

            if (_resourceCache.ContainsKey(enumTypeValue) == false)
            {
                var path = $"{type.Name}/{name}";
                var asset = Resources.Load<Object>(path);

                if (asset == null)
                    throw new UnityException("Can't load resource '" + path + "'");

                _resourceCache[enumTypeValue] = asset;
            }

            return _resourceCache[enumTypeValue];
        }
    }
}