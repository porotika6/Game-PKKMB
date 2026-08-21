using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public SpriteRenderer cloudRenderer;
    public Sprite dayCloud;
    public Sprite nightCloud;
    public float cloudSpeed = 2f;
    public float cycleLength = 1000f;
    public float despawnX = -15f;   
    public float spawnX = 15f;
    public float minY = -5.35f;         
    public float maxY = -1.85f;
    private bool _isnightclouds = false;

    // Update is called once per frame
    
    void Update()
    {
        transform.Translate(Vector2.left * cloudSpeed * Time.deltaTime);

        if (transform.position.x <= despawnX)
        {
            float randomY = Random.Range(minY,maxY);
            float randomX = spawnX + Random.Range(0f, 10f);
            transform.position = new Vector3(randomX, randomY, transform.position.z);

        }
        if (Time.timeScale == 0f) return;
        float rawCycle = ScoreManager.instance.Score / cycleLength;
        float t = rawCycle % 1f;
        float alpha = 1f - Mathf.Abs(t * 2f - 1f);

        // Debug.Log($"score:{ScoreManager.instance.Score:F0} rawCycle:{rawCycle:F3} t:{t:F3} alpha:{alpha:F3}");
        
        bool shouldBeNight = (((int) rawCycle) % 2 == 1);
        if (shouldBeNight != _isnightclouds && alpha < 0.05f)
        {
       _isnightclouds = shouldBeNight;
        cloudRenderer.sprite = _isnightclouds ? nightCloud : dayCloud;
        }

        Color c = cloudRenderer.color;
        c.a = alpha;
        cloudRenderer.color = c;
    }


}