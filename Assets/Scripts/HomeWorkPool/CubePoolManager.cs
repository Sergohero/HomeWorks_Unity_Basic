using System.Collections.Generic;
using UnityEngine;

namespace Scripts.HomeWorkPool
{
    public class CubePoolManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab; 
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero;
    
    private int poolSize = 100; 
    private int activeCubesCount = 10; 
    private float spawnAreaRadius = 5f; 
    private List<GameObject> cubes = new List<GameObject>();
    private int currentGroupIndex = 0;

    private void Start()
    {
        InitializePool();
        InvokeRepeating("SwitchCubes", 1f, 1f);
    }
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(0, -100, 0), Quaternion.identity);
            Renderer renderer = cube.GetComponent<Renderer>();
            
            renderer.material = new Material(renderer.material); 
            renderer.material.color = Random.ColorHSV();
            cube.SetActive(false); 
            cubes.Add(cube);
        }
        ActivateGroup(currentGroupIndex);
    }
    private void SwitchCubes()
    {
        DeactivateGroup(currentGroupIndex);
        currentGroupIndex = (currentGroupIndex + activeCubesCount) % poolSize;
        ActivateGroup(currentGroupIndex);
    }
    private void DeactivateGroup(int startIndex)
    {
        for (int i = startIndex; i < startIndex + activeCubesCount; i++)
        {
            if (i < cubes.Count)
            {
                cubes[i].SetActive(false);
            }
        }
    }
    private void ActivateGroup(int startIndex)
    {
        for (int i = startIndex; i < startIndex + activeCubesCount; i++)
        {
            if (i < cubes.Count)
            {
                GameObject cube = cubes[i];
                cube.SetActive(true);
                Vector3 randomPosition = spawnAreaCenter + new Vector3(Random.Range(-spawnAreaRadius, spawnAreaRadius), Random.Range(-spawnAreaRadius, spawnAreaRadius), Random.Range(-spawnAreaRadius, spawnAreaRadius));
                cube.transform.position = randomPosition;
            }
        }
    }
}
}
