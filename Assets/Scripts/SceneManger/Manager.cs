using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject[] cubes;
    public ManagerData gameData;
    public Procedural procedural;
    public MoveControllers moveControllers;
    

    [ContextMenu("Update Speed")]
    public void UpdateCubeSpeed(float setSpeed)
    {
        gameData.CubeSpeed = setSpeed;
        procedural.UpdateCubeSpeed(setSpeed);
    }

    public void UpdatePlayerSpeed(float setPlayerSpeed)
    {
        gameData.PlayerSpeed = setPlayerSpeed;
        moveControllers.UpdatePlayerSpeed(setPlayerSpeed);
    }
    public void UpdateCubeInstantiationLimits(float setLimit)
    {
        gameData.CubeInstantiationLimits = setLimit;
    }

    public void UpdateName(string name)
    {
        gameData.PlayerName = name;
    }

    [ContextMenu("Kill Cubes")]
    public void killAllCubes()
    {
        cubes = GameObject.FindGameObjectsWithTag("One");
        foreach (GameObject cube in cubes)
            GameObject.Destroy(cube);
    }

}
