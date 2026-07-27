using UnityEngine;

public class GroundLoop : MonoBehaviour
{
     public float scrollSpeed = 5f;
    public float resetX = -20f;    
    public float loopWidth = 40f;  

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= resetX)
            transform.position += new Vector3(loopWidth, 0, 0);
    }
}
