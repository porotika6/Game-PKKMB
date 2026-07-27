using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnX = 12f;   // kanan, di luar layar
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
            int i = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[i], new Vector3(spawnX, transform.position.y, 0), Quaternion.identity);
            _timer = 0f;
            _nextSpawn = Random.Range(minDelay, maxDelay); // jarak acak biar gak monoton
        }
    }
}
