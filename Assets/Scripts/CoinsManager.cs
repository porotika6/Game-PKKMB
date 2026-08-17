using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance;
    [SerializeField] private TextMeshProUGUI _totalCoins;
    private int coins;

    private void Awake()
    {
        if(!instance) instance = this;
    }
    public void ChangeCoins(int amount)
    {
        _totalCoins.text = "Coins: " + coins.ToString();
        coins += amount;
    }
}
