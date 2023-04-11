using UnityEngine;

namespace TankGame 
{
    public class Starter : MonoBehaviour
    {
        private Entity _tankEntity;
        private IResourceManager _resourceManager;
        
        void Awake()
        {
            _resourceManager = new ResourceManager();
            StartGame();
        }
        
        void StartGame()
        {
            CreatePlayer();
            CreateMonsters();
        }

        void CreatePlayer()
        {
            CreateTank();
        }

        void CreateMonsters()
        {
            var enemyCreator = MonoBehaviourExtension.CreateComponent<EnemyCreator>();
            enemyCreator.Initialize(_resourceManager, _tankEntity);
        }

        void CreateTank()
        {
            var tankObject = _resourceManager.GetFromPool(EEntity.Tank);
            
            var weaponController = tankObject.GetComponent<WeaponController>();
            weaponController.Initialize(_resourceManager);
            weaponController.SetWeapon(EWeapons.ShotGun);
            _tankEntity = tankObject.GetComponent<Entity>();
            _tankEntity.SetStats(ConfigReader.ReadConfig<EntityStats>(EConfigs.TankConfig));
            
            var tankController = MonoBehaviourExtension.CreateComponent<TankController>();
            tankController.Initialize(_tankEntity, weaponController, tankObject);
        }
    }
}