using System;

namespace TankGame 
{
    public interface IInputHandler
    {
        public event Action FirstWeaponButtonClicked;
        public event Action SecondWeaponButtonClicked;
        public event Action FireButtonClicked;
    }
}