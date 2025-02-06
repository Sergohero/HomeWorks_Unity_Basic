using UnityEngine;

namespace code
{
    public class TransformExample : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private int _x;
        [SerializeField] private int _y;
        [SerializeField] private int _z;

        private void Start()
        {
            TransformPlayerPos();
            TransformPlayerRotate();
        }

        private void TransformPlayerPos()
        {
            _transform.position = new Vector3(_x, _y, _z);
        }

        private void TransformPlayerRotate()
        {
            _transform.Rotate(Vector3.up * _speed);
        }
    }
}
