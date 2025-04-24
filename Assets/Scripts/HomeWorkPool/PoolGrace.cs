using NTC.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.HomeWorkPool
{
    public class PoolGrace : MonoBehaviour
    {
        [SerializeField] private GameObject _gracePrefab;
    
        private Player _player;
    
        private void Start()
        {
            SpawnGrace();
            _player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            _player.PlayerMovement();
        }

        public void SpawnGrace()
        {
            for (int j = 0; j <= 100; j++)
            {
                float x = Random.Range(-14f, 14f);
                float z = Random.Range(-14f, 14f);
        
                var newPosition = new Vector3(x, 0, z);

                NightPool.Spawn(_gracePrefab, newPosition, Quaternion.identity, transform);
            }
        }
    }
}
