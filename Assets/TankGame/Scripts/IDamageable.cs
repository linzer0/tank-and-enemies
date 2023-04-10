using System;

namespace TankGame 
{
    public interface IDamageable
    {
        public event Action EntityDeath;
        
        void DealDamage(float damage);
    }
}