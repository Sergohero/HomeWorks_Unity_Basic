using System.Collections.Generic;
using UnityEngine;

namespace Scripts.HomeWorkPool
{
    public class CubePoolManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private Vector3 _spawnAreaCenter = Vector3.zero;

        private int _poolSize = 100;
        private int _activeCubesCount = 10;
        private float _spawnAreaRadius = 5f;
        private List<GameObject> _cubes = new List<GameObject>();
        private int _currentGroupIndex = 0;

        private float _spawnInterval = 1f;
        private float _timer = 0f;

        private void Start()
        {
            InitializePool();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval)
            {
                _timer = 0f;
                SpawnAndDespawn();
            }
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                GameObject cube = Instantiate(_cubePrefab, new Vector3(0, -100, 0), Quaternion.identity);
                Renderer renderer = cube.GetComponent<Renderer>();

                renderer.material = new Material(renderer.material); 
                renderer.material.color = Random.ColorHSV();
                cube.SetActive(false);
                _cubes.Add(cube);
            }
            Spawn(_currentGroupIndex);
        }

        private void SpawnAndDespawn()
        {
            Despawn(_currentGroupIndex);

            _currentGroupIndex = (_currentGroupIndex + _activeCubesCount) % _poolSize;

            Spawn(_currentGroupIndex);
        }

        private void Despawn(int startIndex)
        {
            for (int i = startIndex; i < startIndex + _activeCubesCount; i++)
            {
                if (i < _cubes.Count)
                {
                    _cubes[i].SetActive(false);
                }
            }
        }

        private void Spawn(int startIndex)
        {
            for (int i = startIndex; i < startIndex + _activeCubesCount; i++)
            {
                if (i < _cubes.Count)
                {
                    GameObject cube = _cubes[i];
                    cube.SetActive(true);

                    Vector3 randomPosition = _spawnAreaCenter +
                        new Vector3(
                            Random.Range(-_spawnAreaRadius, _spawnAreaRadius),
                            Random.Range(-_spawnAreaRadius, _spawnAreaRadius),
                            Random.Range(-_spawnAreaRadius, _spawnAreaRadius)
                        );

                    cube.transform.position = randomPosition;
                }
            }
        }
    }
}

