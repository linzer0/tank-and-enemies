using System.Collections;
using UnityEngine;

namespace TankGame
{
    public sealed class Rusher : Enemy
    {
        private enum RusherState
        {
            Idle,
            Waiting,
            Running
        }

        private Vector3 _movePosition;
        private RusherState _currentState = RusherState.Idle;


        void Update()
        {
            if (EntityIsActive())
            {
                if (_currentState == RusherState.Idle)
                {
                    _currentState = RusherState.Waiting;
                    StartCoroutine(WaitIdleTime());
                }

                if (_currentState == RusherState.Running)
                {
                    if (Vector3.Distance(Entity.EntityObject.transform.position, _movePosition) > 1)
                    {
                        transform.LookAt(_movePosition);
                        transform.Translate(Vector3.forward * GetRusherSpeed() * Time.deltaTime);
                    }
                    else
                    {
                        _currentState = RusherState.Idle;
                    }
                }
            }
        }

        private IEnumerator WaitIdleTime()
        {
            yield return new WaitForSeconds(Random.Range(2, 5f));
            _movePosition = TargetTransform.position;
            _currentState = RusherState.Running;
        }

        private float GetRusherSpeed()
        {
            var speed = Entity.GetSpeed();
            speed += Random.Range(0, 5f);
            return speed;
        }
    }
}