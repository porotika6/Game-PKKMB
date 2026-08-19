using UnityEngine;

public class Jump_Bonus : MonoBehaviour
{
    public int bonusScore = 30;
    private bool _scored = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_scored)
        {
            _scored = true;
          Debug.Log("Before: " + ScoreManager.instance._score);
          ScoreManager.instance.AddScore(bonusScore);
          Debug.Log("After: " + ScoreManager.instance._score);
        }
    }
}
