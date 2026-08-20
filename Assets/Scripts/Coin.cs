using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private float despawnX = -15f;
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
            Debug.Log("COIN TERAMBIL");

            ScoreManager.instance.AddScore(_value);
            ScoreManager.instance.CoinCollected();
            Destroy(gameObject);
        }
    }
    private void MoveToLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x < despawnX) Destroy(gameObject);
    }    
}