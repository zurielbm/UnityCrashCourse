using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareScript : MonoBehaviour
{

    public string PlayerPref;
    public string JSON;

    public TextAsset JSONFile;

    [ContextMenu("Get Json")]
    private void Start()
    {
        Debug.Log(JSONFile);
    }

    public string GetJSON
    {

        get { return JSONFile.ToString(); }
    }



    public string GetPlayerPref
    {
       
       get { return PlayerPrefs.GetString("weather"); }
    }

}
