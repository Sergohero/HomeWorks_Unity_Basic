using UnityEngine;

namespace code
{
    public class UseMedkit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
