using UnityEngine;

public class RigidBodyExample : MonoBehaviour
{
    private Rigidbody _rb;
    private float _pow = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * (_pow * Time.deltaTime));
    }
}
