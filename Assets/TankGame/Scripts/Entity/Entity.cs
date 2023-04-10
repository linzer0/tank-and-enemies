using System;
using UnityEngine;

namespace TankGame
{
    public class Entity : MonoBehaviour, IDamageable
    {
        public event Action EntityDeath = () => { };

        [SerializeField] protected float speed = 2;
        [SerializeField] protected float armor = 0.5f;
        [SerializeField] protected float health = 100;

        public GameObject EntityObject => gameObject;

        private float _currentHealth;

        private void OnEnable()
        {
            _currentHealth = health;
        }

        public void DealDamage(float damage)
        {
            if (IsAlive())
            {
                _currentHealth -= damage * armor;
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
            return speed;
        }

        private void OnDisable()
        {
            EntityDeath = null;
        }
    }
}