using System;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform weaponParent;
        private Dictionary<EWeapons, Weapon> _weaponDictionary;
        private EWeapons _currentWeapon = EWeapons.None;

        private IResourceManager ResourceManager;

        private void Awake()
        {
            _weaponDictionary = new Dictionary<EWeapons, Weapon>();
        }

        public void Initialize(IResourceManager resourceManager)
        {
            ResourceManager = resourceManager;
        }

        public void DisableCurrentWeapon()
        {
            if (_weaponDictionary.ContainsKey(_currentWeapon))
            {
                _weaponDictionary[_currentWeapon].Disable();
            }
        }

        public void SetWeapon(EWeapons weaponType)
        {
            if (_weaponDictionary.ContainsKey(weaponType))
            {
                _weaponDictionary[weaponType].Enable();
            }
            else
            {
                var weaponComponent = CreateWeapon(weaponType);
                _weaponDictionary.Add(weaponType, weaponComponent);
            }

            _currentWeapon = weaponType;
        }

        private Weapon CreateWeapon(EWeapons weaponType)
        {
            var weaponObject = ResourceManager.GetFromPool(weaponType);
            weaponObject.transform.SetParent(weaponParent, false);
            
            var weaponComponent = weaponObject.GetComponent<Weapon>();
            weaponComponent.Initialize(ResourceManager);
            return weaponComponent;
        }

        public Weapon GetCurrentWeapon()
        {
            if (_weaponDictionary.ContainsKey(_currentWeapon))
            {
                return _weaponDictionary[_currentWeapon];
            }

            throw new Exception("Not active weapon");
        }
    }
}