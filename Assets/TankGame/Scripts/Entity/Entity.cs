using System;
using UnityEngine;

namespace TankGame
{
    public class Entity : MonoBehaviour, IDamageable
    {
        public event Action EntityDeath = () => { };

        [SerializeField] protected EConfigs stats;

        public EConfigs Stats => stats;

        public GameObject EntityObject => gameObject;

        private float _currentHealth;
        private EntityStats _entityStats;
        
        public void SetStats(EntityStats entityStats)
        {
            _currentHealth = entityStats.Health;
            _entityStats = entityStats;
        }

        public void DealDamage(float damage)
        {
            if (IsAlive())
            {
                _currentHealth -= damage * _entityStats.Armor;
            }
            else
            {
                EntityDeath();
                EntityObject.SetActive(false);
            }
        }

        public bool IsAlive()
        {
            return _currentHealth > 0;
        }

        public float GetSpeed()
        {
            return _entityStats.Speed;
        }

        private void OnDisable()
        {
            EntityDeath = () => { };
        }
    }
}