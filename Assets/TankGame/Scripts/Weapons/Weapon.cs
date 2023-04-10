using System;
using UnityEngine;

namespace TankGame
{
    public interface IWeapon
    {
        public Projectile GetProjectile();
    }

    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] protected EProjectiles projectileType = EProjectiles.None;
        [SerializeField] protected Transform projectileStartPosition;
        [SerializeField] protected float damageValue;
        [SerializeField] protected float projectileSpeed = 250;

        private IResourceManager _resourceManager;

        public abstract void Fire();

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Initialize(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public Projectile GetProjectile()
        {
            if (projectileType == EProjectiles.None)
            {
                throw new Exception("Projectile type not set");
            }

            var projectileObject = _resourceManager.GetFromPool(projectileType);
            var projectileComponent = projectileObject.GetComponent<Projectile>();
            projectileComponent.ResetProjectile();
            return projectileComponent;
        }

        protected void DealDamage(GameObject collidedObject)
        {
            var entity = collidedObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.DealDamage(damageValue);
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}