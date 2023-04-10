using UnityEngine;

namespace TankGame 
{
    public class TankController : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private WeaponController _weaponController;
        private GameObject _tankObject;
        private Entity _tank;
        private readonly float _rotationSpeed = 100f;

        public void Initialize(Entity tank, WeaponController weaponController, GameObject tankObject)
        {
            _tank = tank;
            _weaponController = weaponController;
            _tankObject = tankObject;
        }

        private void Awake()
        {
            _inputHandler = MonoBehaviourExtension.CreateComponent<InputHandler>();
            _inputHandler.FirstWeaponButtonClicked += SetFirstWeapon;
            _inputHandler.SecondWeaponButtonClicked += SetSecondWeapon;
            _inputHandler.FireButtonClicked += Fire;
        }

        private void Fire()
        {
            var currentWeapon = _weaponController.GetCurrentWeapon();
            currentWeapon.Fire();
        }

        void Update()
        {
            if (Input.GetButton("Vertical"))
            {
                var verticalValue = Input.GetAxis("Vertical") > 0 ? 1 : -1;

                _tankObject.transform.position += _tankObject.transform.forward * (verticalValue * (_tank.GetSpeed() * Time.deltaTime));
            }

            if (Input.GetButton("Horizontal"))
            {
                var rotationValue = Input.GetAxis("Horizontal");

                _tankObject.transform.Rotate(Vector3.up * (_rotationSpeed * rotationValue * Time.deltaTime));
            }
        }

        private void SetFirstWeapon()
        {
            _weaponController.DisableCurrentWeapon();
            _weaponController.SetWeapon(EWeapons.ShotGun);
        }

        private void SetSecondWeapon()
        {
            _weaponController.DisableCurrentWeapon();
            _weaponController.SetWeapon(EWeapons.HeavyGun);
        }
    }
}