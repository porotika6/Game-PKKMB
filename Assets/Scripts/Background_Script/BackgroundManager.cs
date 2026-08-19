using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BackgroundManager : MonoBehaviour
{
 public static BackgroundManager instance; 
 public Light2D globalLight;   
  public SpriteRenderer nightSky; 
  public SpriteRenderer nightBuilding;
  public float dayLightIntensity = 1f;
  public float nightLightIntensity = 0.2f;
  public float cycleLength = 1000f;
  private float _lastAlpha = 0f;

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.PingPong(ScoreManager.instance._score / cycleLength, 1f);         
        bool goingToDay = alpha < _lastAlpha;
            _lastAlpha = alpha;

        nightSky.color = new Color(nightSky.color.r, nightSky.color.g, nightSky.color.b, alpha);
        nightBuilding.color = new Color(nightBuilding.color.r, nightBuilding.color.g, nightBuilding.color.b, alpha);

        float lightValue = alpha;
        if (goingToDay)
            lightValue = Mathf.Pow(alpha, 0.2f);

        globalLight.intensity = Mathf.Lerp(dayLightIntensity, nightLightIntensity, lightValue);

    }

    public bool isNight()
    {
        return nightSky.color.a > 0.5f;
    }

        
}

