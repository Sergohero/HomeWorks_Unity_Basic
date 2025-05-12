using UnityEngine;

namespace code
{
    public class UseMedkit : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _pickupSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_pickupSound.Length > 0 && _audioSource != null)
            {
                AudioClip randomClip = _pickupSound[Random.Range(0, _pickupSound.Length)];
                _audioSource.PlayOneShot(randomClip);
                Destroy(gameObject, randomClip.length);
            }
        }
    }
}