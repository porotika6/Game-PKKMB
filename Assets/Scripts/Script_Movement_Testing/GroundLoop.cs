using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float resetX = -20f;    
    public float loopWidth = 40f;  

    void Update()
    {
        float Speed = ScoreManager.instance.gameSpeed;
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if (transform.position.x <= resetX)
            transform.position += new Vector3(loopWidth, 0, 0);
            
    }
}
