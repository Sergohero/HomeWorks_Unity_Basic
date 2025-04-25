using UnityEngine;

namespace Scripts.HomeWorkEnemySpawn
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _speed = 10f;

      
        private void Start()
        {
            Instantiate(_playerPrefab, transform);
        }

        private void Update()
        {
            PlayerMovement();
        }

        public void PlayerMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
