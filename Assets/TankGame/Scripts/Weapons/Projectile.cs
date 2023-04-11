using System;
using System.Collections;
using UnityEngine;

namespace TankGame
{
    public interface IProjectile
    {
        public event Action<GameObject> ObjectCollision;
    }

    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private LayerMask targetLayer;

        public event Action<GameObject> ObjectCollision = (x) => { };
        public Rigidbody Rigidbody => rigidbody;

        private float _deactivationTime = 3.5f;

        void OnEnable()
        {
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            yield return new WaitForSeconds(_deactivationTime);
            gameObject.SetActive(false);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (MonoBehaviourExtension.IsTargetMask(targetLayer, collision.gameObject))
            {
                ObjectCollision(collision.gameObject);
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            Rigidbody.velocity = new Vector3(0f, 0f, 0f);
            Rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
        }

        public void ResetProjectile()
        {
            ObjectCollision = (x) => {};
        }
    }
}