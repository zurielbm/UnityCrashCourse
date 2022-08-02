using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weather Data", menuName = "Weather Data")]
[Serializable]
public class WeatherData : ScriptableObject
{
  
    [SerializeField]
    public Properties properties = new();

}

[Serializable]
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Elevation
    {
        public string unitCode ;
        public string value ;
    }
    [Serializable]
    public class Geometry
    {
        public string type ;
        public List<List<List<double>>> coordinates ;
    }
    [Serializable]
    public class Period
    {

        public int number ;
        public string name ;
        public DateTime startTime ;
        public DateTime endTime ;
        public bool isDaytime ;
        public int temperature ;
        public string temperatureUnit ;
        public object temperatureTrend ;
        public string windSpeed ;
        public string windDirection ;
        public string icon ;
        public string shortForecast ;
        public string detailedForecast ;
    }
    [Serializable]
    public class Properties
    {
        public DateTime updated ;
        public string units ;
        public string forecastGenerator ;
        public DateTime generatedAt ;
        public DateTime updateTime ;
        public string validTimes ;
        public Elevation elevation ;
        public Period[] periods ;
    }
    