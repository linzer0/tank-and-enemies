using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class EnemyCreator : MonoBehaviour
    {
        private Entity _tankEntity;
        private List<Vector3> _listOfZones;
        private IResourceManager _resourceManager;

        private List<EEntity> _enemyTypes;
        private int _enemyAmount = 10;
        private Dictionary<EEntity, EntityStats> _entityStats;

        private void Awake()
        {
            _enemyTypes = new List<EEntity>() { EEntity.Follower, EEntity.Rusher };
            _entityStats = new Dictionary<EEntity, EntityStats>();
            _listOfZones = new List<Vector3>
            {
                Camera.main.ViewportToWorldPoint(Vector3.left),
                Camera.main.ViewportToWorldPoint(Vector3.right),
                Camera.main.ViewportToWorldPoint(Vector3.up),
                Camera.main.ViewportToWorldPoint(Vector3.down)
            };
        }

        public void Initialize(IResourceManager resourceManager, Entity tankEntity)
        {
            var followerConfig = ConfigReader.ReadConfig<EntityStats>(EConfigs.FollowerConfig);
            _resourceManager = resourceManager;
            _tankEntity = tankEntity;

            for (int i = 0; i < _enemyAmount; i++)
            {
                CreateRandomEnemy();
            }
        }

        private void CreateRandomEnemy()
        {
            var randomEntity = _enemyTypes[Random.Range(0, _enemyTypes.Count)];
            CreateEnemy(randomEntity);
        }

        private void CreateEnemy(EEntity enemyType)
        {
            var enemyObject = _resourceManager.GetFromPool(enemyType);
            enemyObject.transform.position = GetEnemyPosition();

            var enemyComponent = enemyObject.GetComponent<Enemy>();
            var stats = GetStats(enemyType, enemyComponent.Entity.Stats);
            enemyComponent.InitializeEntity(stats);
            enemyComponent.Entity.EntityDeath += CreateRandomEnemy;
            enemyComponent.SetTarget(_tankEntity);
            enemyComponent.StartBehaviour();
        }

        private EntityStats GetStats(EEntity entityType, EConfigs config)
        {
            if (_entityStats.ContainsKey(entityType) == false)
            {
                _entityStats.Add(entityType, ConfigReader.ReadConfig<EntityStats>(config));
            }

            return _entityStats[entityType];
        }


        private Vector3 GetEnemyPosition()
        {
            var spawnPosition = _listOfZones[Random.Range(0, _listOfZones.Count)];
            spawnPosition += new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            spawnPosition.y = 1;
            return spawnPosition;
        }
    }
}