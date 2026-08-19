using UnityEngine;

public class CycleMover : MonoBehaviour
{
    public static CycleMover instance;
    public SpriteRenderer celestialRenderer;
    public Sprite sunSprite;
    public Sprite moonSprite;
    public float cycleLength = 1000f;   // same idea as the sky — how long one crossing takes
    public float rightX = 12f;          // enters from right (off-screen)
    public float leftX = -12f;          // exits to left (off-screen)
    public float skyY = 4f;             // height in the sky

    private bool _lastWasSun = true;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        // how far through the current crossing (0 = just entered right, 1 = about to exit left)
        float progress = (ScoreManager.instance._score % cycleLength) / cycleLength;

        // slide from right to left based on progress (one direction, no bounce)
        float x = Mathf.Lerp(rightX, leftX, progress);
        transform.position = new Vector3(x, skyY, transform.position.z);

        // figure out which crossing number we're on (0,1,2,3...) — even = sun, odd = moon
        int crossingNumber = (int)(ScoreManager.instance._score / cycleLength);
        bool shouldBeSun = (crossingNumber % 2 == 0);

        // only swap the sprite when it changes (avoids swapping every frame)
        if (shouldBeSun != _lastWasSun)
        {
            _lastWasSun = shouldBeSun;
            celestialRenderer.sprite = shouldBeSun ? sunSprite : moonSprite;
        }
    }

    public bool ismoonUp()
    {
        int crossingNumber = (int)(ScoreManager.instance._score / cycleLength);
        return (crossingNumber % 2 == 1);
    }
}
