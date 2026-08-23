using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   public Animator animator;      // drag Animator dari child "Square"
    public Rigidbody2D rb;         // drag Rigidbody2D dari parent

    private string _currentState;

    void Update()
    {
        // belum mulai (timeScale 0) -> Idle
        if (Time.timeScale == 0f)
        {
            ChangeState("Idle");
            return;
        }

        // di udara -> Jump, di tanah -> Run
        bool isInAir = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (isInAir)
            ChangeState("Jump");
        else
            ChangeState("Run");
    }

    void ChangeState(string newState)
    {
        if (_currentState == newState) return;   // biar animasi nggak restart tiap frame
        animator.Play(newState);
        _currentState = newState;
    }
}
