using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject[] cubes;
    public ManagerData gameData;
    public Procedural procedural;
    public MoveControllers moveControllers;
    private float pastCubeAmount;
    private float currentCubeAmount;
    private GameObject[] cubesArray;
    private int amountToRemove = 0;
    private void Start()
    {
        pastCubeAmount = gameData.CubeInstantiationLimits;
        currentCubeAmount = gameData.CubeInstantiationLimits;
        StartCoroutine(SlowlySpawnCubes());
    }

    private void Update()
    {
        currentCubeAmount = gameData.CubeInstantiationLimits;
        if (pastCubeAmount < currentCubeAmount)
        {
            pastCubeAmount = currentCubeAmount;
            StartCoroutine(SlowlySpawnCubes());
        } else if (pastCubeAmount > currentCubeAmount)
        {
            pastCubeAmount = currentCubeAmount;
            RemoveSpawnCubes(currentCubeAmount);
        }
    }


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
            Destroy(cube);
    }

    IEnumerator SlowlySpawnCubes()
    {
        while (PoolSpawning.SharedInstance.pool.CountAll < gameData.CubeInstantiationLimits )
        {
            Debug.Log( " - " + PoolSpawning.SharedInstance.pool.CountAll);
            PoolSpawning.SharedInstance.pool.Get();
            yield return new WaitForSeconds(5f);
          
            Debug.Log(" -___- " + PoolSpawning.SharedInstance.pool.CountAll);
        }
        Debug.Log("finished Spawing cubes");
    }

    private void RemoveSpawnCubes(float currentCubeAmount)
    {
        int intCurrentCubeAmount = (int)currentCubeAmount;
        Debug.Log("Remving");
        cubesArray = GameObject.FindGameObjectsWithTag("One");
        amountToRemove = cubesArray.Length - intCurrentCubeAmount;
       Debug.Log(amountToRemove);   
        for(int i = 0; i < amountToRemove; i++)
            PoolSpawning.SharedInstance.pool.Release(cubesArray[i]); 
    }

}
