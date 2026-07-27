using UnityEngine;

public class Obstacle : MonoBehaviour
{
   public float speed = 5f;
    public float despawnX = -15f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= despawnX)
            Destroy(gameObject);
    }
}
