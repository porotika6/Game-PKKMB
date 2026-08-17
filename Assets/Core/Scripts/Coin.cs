using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    private bool _hasTriggered;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !_hasTriggered)
        {
            _hasTriggered = true;
            CoinsManager.instance.ChangeCoins(_value);
            Destroy(gameObject);
        }
    }
}
