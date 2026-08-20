using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Obstacle")]
    public GameObject[] obstaclePrefabs;

    [Header("Coin")]
    public GameObject coinPrefab;
    [Range(0f, 1f)] public float coinSpawnChance = 0.15f; // 15% peluang jadi coin, sisanya obstacle

    [Header("Timing spawn")]
    public float spawnX = 12f;
    public float minDelay = 1f;
    public float maxDelay = 2f;

    private float _timer;
    private float _nextSpawn;

    void Start()
    {
        _nextSpawn = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _nextSpawn)
        {
            SpawnObject();
            _timer = 0f;
            _nextSpawn = Random.Range(minDelay, maxDelay);
        }
    }

    private void SpawnObject()
    {
        GameObject prefabToSpawn;

        if (coinPrefab != null && Random.value < coinSpawnChance)
            prefabToSpawn = coinPrefab;
        else
            prefabToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        Instantiate(prefabToSpawn, new Vector3(spawnX, prefabToSpawn.transform.position.y, 0), Quaternion.identity);
    }
}