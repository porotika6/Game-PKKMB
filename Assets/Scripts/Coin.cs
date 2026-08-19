using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    // private bool _hasTriggered;
    float speed;

    void Awake()
    {
        speed = ScoreManager.instance.gameSpeed;
    }
    void Update()
    {
        MoveToLeft();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(_value);
            Destroy(gameObject);
        }
    }
    private void MoveToLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }    
}
