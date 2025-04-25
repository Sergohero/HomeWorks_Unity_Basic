using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.HomeWorkEnemySpawn
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;

        private int _maxEnemies = 10;
        private int _currentEnemies = 0;
        private float _spawnDelay;

        private void Start()
        {
            StartCoroutine(Spawner());
        }

        private void SpawnerEnemy()
        {
            float spawnX = Random.Range(14f, -14f);
            float spawnZ = Random.Range(14f, -14f);
            Vector3 spawnPos = new Vector3(spawnX, 0f, spawnZ);

            Instantiate(_enemyPrefab, spawnPos, Quaternion.identity, transform);
            _currentEnemies++;
        }

        private IEnumerator Spawner()
        {
            while (true)
            {
                _spawnDelay = Random.Range(1f, 2f);
                if (_currentEnemies <= _maxEnemies)
                {
                    SpawnerEnemy();
                }
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}


