using UnityEngine;

namespace BattleSystem
{
    public class DragonHealth : Health
    {
        [SerializeField] private int _daragonWasDamagedHealthReducer = 200;

        protected override void Start()
        {
            PlayerData pl = SaveManager.LoadPlayerData();
            if (pl.dragon_was_damaged)
            {
                _currentValue = _count - _daragonWasDamagedHealthReducer;
            }
            else 
            {
                _currentValue = _count;
            }
            _hpBar.UpdateValue(_currentValue, _count);
        }
    }
}