using UnityEngine;

namespace TankGame 
{
    public class HeavyGun : Weapon
    {
        public override void Fire()
        {
            var projectile = GetProjectile();
            projectile.ObjectCollision += DealDamage;
            
            projectile.transform.position = projectileStartPosition.position;
            projectile.Rigidbody.AddForce(projectileStartPosition.forward * projectileSpeed, ForceMode.Force);
        }
    }
}