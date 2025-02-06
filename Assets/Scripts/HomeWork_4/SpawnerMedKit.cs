using UnityEngine;

namespace code
{
    public class SpawnerMedKit : MonoBehaviour
    {
        [SerializeField] private MedKit _medKitPrefab;
        [SerializeField] private Transform _spawnPoint;

        private MedKit _medKit;

        private void Start()
        {
            SpawnMedKit();
            RandomSpawnPoint();
        }

        private void SpawnMedKit()
        {
            _medKit = Instantiate(_medKitPrefab, _spawnPoint);
        }

        private void RandomSpawnPoint()
        {
            for (int i = 0; i < 5; i++)
            {
                int x = Random.Range(-12, 12);
                int z = Random.Range(-12, 12);

                Vector3 pos = new Vector3(x, 0, z);
                _spawnPoint.position = pos;
                _spawnPoint = Instantiate(_spawnPoint);
            }
        }

    }
}
