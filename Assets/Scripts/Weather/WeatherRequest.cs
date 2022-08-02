using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class WeatherRequest : MonoBehaviour
{
    public WeatherData WeatherData;
     WeatherData WeatherObj;
    [ContextMenu("Get weather")]
    private void Start()
    {
       StartCoroutine(GetWeather("42.44188", "-121.271602"));
    }

    public void GetForcast(string lat, string lon)
    {
        StartCoroutine(GetWeather(lat, lon ));
        Debug.Log(lat + lon);
      
    }


 IEnumerator GetWeather(string lat, string lon)
    {
        
      string weatherLocationUrl = "https://api.weather.gov/points/" + lat + "," + lon;

        UnityWebRequest www = UnityWebRequest.Get(weatherLocationUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            JObject weatherlocation = JObject.Parse(www.downloadHandler.text.ToString());
            string weatherApiUrl = weatherlocation["properties"]["forecast"].ToString();
            StartCoroutine(GetWeatherForcast(weatherApiUrl));
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }

    }

    IEnumerator GetWeatherForcast(string weatherApiUrl)
    {

        UnityWebRequest www = UnityWebRequest.Get(weatherApiUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            WeatherObj = JsonConvert.DeserializeObject<WeatherData>(www.downloadHandler.text);
            System.IO.File.WriteAllText("Assets/path.text", www.downloadHandler.text);
            PlayerPrefs.SetString("weather", www.downloadHandler.text);
            Debug.Log(PlayerPrefs.GetString("weather"));
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

           
        }
        WeatherData.properties = WeatherObj.properties;
       
    }

}
