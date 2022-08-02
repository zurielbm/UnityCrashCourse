using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    WeatherRequest weatherRequest;
    

    public string longitude;
    public string latitude;

   public void clicked()
    {
        weatherRequest = GameObject.FindGameObjectWithTag("Script").GetComponent<WeatherRequest>();
        Debug.Log("Clicked");
        weatherRequest.GetForcast(latitude, longitude);
      
    }

    
}