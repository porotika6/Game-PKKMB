using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public SpriteRenderer cloudRenderer;
    public Sprite dayCloud;
    public Sprite nightCloud;
    public float cloudSpeed = 2f;
    public float despawnX = -15f;   
    public float spawnX = 15f;      
    public float minY = -5.35f;         
    public float maxY = -1.85f;
    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector2.left * cloudSpeed * Time.deltaTime);

        if (transform.position.x <= despawnX)
        {
            float randomY = Random.Range(minY,maxY);
            float randomX = spawnX + Random.Range(0f, 10f);
            transform.position = new Vector3(spawnX, randomY, transform.position.z);

            if (BackgroundManager.instance.isNight())
                cloudRenderer.sprite = nightCloud;
            else
                cloudRenderer.sprite = dayCloud;
        }
  
    }

}
