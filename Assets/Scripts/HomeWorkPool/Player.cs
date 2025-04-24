using System.Collections;
using NTC.Pool;
using UnityEngine;

public class Player : MonoBehaviour
{
      [SerializeField] private GameObject _playerPrefab;
      [SerializeField] private float _speed = 10f;

      
      private void Start()
      {
            Instantiate(_playerPrefab, transform);
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
                  NightPool.Despawn(other.gameObject, 0.1f);
            }
      }
}
