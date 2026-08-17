using UnityEngine;


public class BackgroundManager : MonoBehaviour
{
 public static BackgroundManager instance; 
  public SpriteRenderer nightSky; 
  public SpriteRenderer nightBuilding;
  public float cycleLength = 1000f;

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
  {
       float alpha = Mathf.PingPong(Scoremanager.instance._score / cycleLength, 1f);         

       nightSky.color = new Color(nightSky.color.r, nightSky.color.g, nightSky.color.b, alpha);
       nightBuilding.color = new Color(nightBuilding.color.r, nightBuilding.color.g, nightBuilding.color.b, alpha); 
  }

    public bool isNight()
    {
        return nightSky.color.a > 0.5f;
    }

        
}

