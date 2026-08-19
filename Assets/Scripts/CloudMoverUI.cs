using UnityEngine;

public class CloudMoverUI : MonoBehaviour
{
    public float cloudSpeed;
    public float despawnX;
    public float spawnX;
    public float minY;
    public float maxY;

    void Update()
    {
        transform.Translate(Vector2.left * cloudSpeed * Time.deltaTime);

        if(transform.position.x <= despawnX)
        {
            float randomY = Random.Range(minY, maxY);
            transform.position = new Vector2(spawnX, randomY);
        }
    }
}
