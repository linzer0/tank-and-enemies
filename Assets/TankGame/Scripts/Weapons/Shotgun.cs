using System.Collections.Generic;
using UnityEngine;

namespace TankGame 
{
    public class Shotgun : Weapon
    {
        [SerializeField] private Transform secondProjectileStartPosition;
        [SerializeField] private Transform thirdProjectileStartPosition;

        private List<Transform> _projectilePositions;
        private readonly float _projectileSpeed = 250;

        private void Awake()
        {
            _projectilePositions = new List<Transform>()
            {
                projectileStartPosition,
                secondProjectileStartPosition,
                thirdProjectileStartPosition
            };
        }

        public override void Fire()
        {
            foreach (var barrelTransform in _projectilePositions)
            {
                var projectile = GetProjectile();
                projectile.ObjectCollision += DealDamage;
                
                projectile.transform.position = barrelTransform.position;
                projectile.Rigidbody.AddForce(barrelTransform.forward * _projectileSpeed, ForceMode.Force);
            }
        }
    }
}