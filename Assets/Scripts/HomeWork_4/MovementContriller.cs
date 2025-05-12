using System.Collections;
using UnityEngine;

namespace code
{
    public class MovementContriller : MonoBehaviour
    {
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioClip movementSound;
        
        private AudioSource audioSource; 

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
            
            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Move(movement);
            MovementSound();
        }

        private void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _speed;
            _rb.velocity = new Vector3(velocity.x, 0, velocity.z);

            _animator.SetFloat("Speed", velocity.magnitude);
        }

        private void MovementSound()
        {
            float currentSpeed = _rb.velocity.magnitude;
            if (currentSpeed > 0.1f && !audioSource.isPlaying && movementSound != null)
            {
                audioSource.clip = movementSound;
                audioSource.loop = true;
                audioSource.Play();
            }
            else if (currentSpeed <= 0.1f && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
