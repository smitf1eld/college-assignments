using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnRate = 2f;
    public float spawnHeight = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCube();
            timer = 0;
        }
    }

    void SpawnCube()
    {
        float randomY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(cubePrefab, spawnPos, Quaternion.identity);
    }
}