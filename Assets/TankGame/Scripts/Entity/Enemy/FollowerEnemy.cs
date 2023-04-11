using UnityEngine;

namespace TankGame 
{
    public sealed class FollowerEnemy : Enemy
    {
        void Update()
        {
            if (EntityIsActive())
            {
                if (Vector3.Distance(Entity.EntityObject.transform.position, TargetTransform.position) > 1)
                {
                    transform.LookAt(TargetTransform);
                    transform.Translate(Vector3.forward * Entity.GetSpeed() * Time.deltaTime);
                }
            }
        }
    }
}