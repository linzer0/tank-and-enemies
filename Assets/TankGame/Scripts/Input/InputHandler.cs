using System;
using UnityEngine;

namespace TankGame 
{
    public class InputHandler : MonoBehaviour, IInputHandler
    {
        public event Action FirstWeaponButtonClicked = () => { };
        public event Action SecondWeaponButtonClicked = () => { };
        public event Action FireButtonClicked = () => { };

        void Update()
        {
            if (Input.GetButtonDown(EInputCommands.FirstWeapon.ToString()))
            {
                FirstWeaponButtonClicked();
            }

            else if (Input.GetButtonDown(EInputCommands.SecondWeapon.ToString()))
            {
                SecondWeaponButtonClicked();
            }

            else if (Input.GetButtonDown(EInputCommands.Shoot.ToString()))
            {
                FireButtonClicked();
            }
        }
    }
}