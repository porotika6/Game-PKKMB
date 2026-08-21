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
        if(Time.timeScale == 0f) return;
        float alpha = Mathf.PingPong(ScoreManager.instance.Score / cycleLength, 1f);         
        bool goingToDay = alpha < _lastAlpha;
            _lastAlpha = alpha;

        float targetSkyAlpha = alpha;
        float currentSkyAlpha = nightSky.color.a;
        float smoothAlpha = Mathf.Lerp(currentSkyAlpha, targetSkyAlpha, Time.deltaTime * 3f);

        nightSky.color = new Color(nightSky.color.r, nightSky.color.g, nightSky.color.b, alpha);
        nightBuilding.color = new Color(nightBuilding.color.r, nightBuilding.color.g, nightBuilding.color.b, alpha);

        float lightValue = alpha;
        if (goingToDay)
            lightValue = Mathf.Pow(smoothAlpha, 0.2f);

        globalLight.intensity = Mathf.Lerp(dayLightIntensity, nightLightIntensity, lightValue);

    }

    public bool isNight()
    {
        return nightSky.color.a > 0.5f;
    }

        
}

