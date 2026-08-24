using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite gameOverSprite;

    void OnEnable()
    {
        // dengerin event game over
        if (Game_Over.instance != null)
            Game_Over.instance.OnGameOver += HandleGameOver;
    }
    void OnDisable()
    {
        // berhenti dengerin (biar nggak error pas object hilang)
        if (Game_Over.instance != null)
            Game_Over.instance.OnGameOver -= HandleGameOver;
    }

    void HandleGameOver()
    {
        animator.enabled = false;              // matiin animator (biar sprite nggak ketimpa)
        spriteRenderer.sprite = gameOverSprite; // ganti ke sprite game over
    }
}
