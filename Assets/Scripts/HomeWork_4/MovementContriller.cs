using UnityEngine;

namespace code
{
    public class MovementContriller : MonoBehaviour
    {
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Move(movement);
        }

        private void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _speed;
            _rb.velocity = new Vector3(velocity.x, 0, velocity.z);

            _animator.SetFloat("Speed", velocity.magnitude);
        }
    }
}
