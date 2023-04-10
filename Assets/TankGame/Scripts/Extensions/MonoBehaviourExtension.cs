using UnityEngine;

namespace TankGame 
{
    public static class MonoBehaviourExtension
    {
        public static T CreateComponent<T>() where T : Component
        {
            var gameObject = new GameObject
            {
                name = typeof(T).Name
            };

            var component = gameObject.AddComponent<T>();
            return component;
        }
        
        public static bool IsTargetMask(LayerMask targetLayer, GameObject targetObject)
        {
            return (targetLayer == (targetLayer | (1 << targetObject.layer)));
        }
    }
}