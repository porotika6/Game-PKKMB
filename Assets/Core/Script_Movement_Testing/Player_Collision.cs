using UnityEngine;

public class Player_Collision : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("HIT");
        }
    }
}