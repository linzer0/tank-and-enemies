using UnityEngine;

namespace TankGame
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float damage;
        [SerializeField] protected Entity entity;
        [SerializeField] protected LayerMask targetLayerMask;

        public Entity Entity => entity;

        protected Entity TargetEntity;
        protected Transform TargetTransform;
        protected bool BehaviourIsStarted = false;

        public void SetTarget(Entity targetEntity)
        {
            TargetEntity = targetEntity;
        }

        public virtual void StartBehaviour()
        {
            TargetTransform = TargetEntity.EntityObject.transform;
            BehaviourIsStarted = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (MonoBehaviourExtension.IsTargetMask(targetLayerMask, collision.gameObject))
            {
                TargetEntity.DealDamage(damage);
            }
        }

        protected bool EntityIsActive()
        {
            return BehaviourIsStarted && TargetEntity.IsAlive();
        }
    }
}