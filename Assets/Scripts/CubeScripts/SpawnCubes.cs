using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    // Assign a Rigidbody component in the inspector to instantiate\

    private UnityEngine.GameObject[] cubeSetAmount;
    public ManagerData gameData;
    public UnityEngine.GameObject cube;

    public int xPos;
    public int yPos;
    float inQueue = 1f;

   /* private void Update()
    {
        cubeSetAmount = GameObject.FindGameObjectsWithTag("One");
        if ( cubeSetAmount.Length + inQueue <= gameData.CubeInstantiationLimits)
        StartCoroutine(AutoRespawn());
    }
*/
    /*public void SpawnCubeSet()
    {
        if(cube == null) {
            Debug.Log(cube);
            return; 
        }
        xPos = Random.Range(-40, 40);
        yPos = Random.Range(-40, 40);
        Instantiate(cube, new Vector3(xPos, 1, yPos), Quaternion.identity );
    }*/

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
      
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (hit.collider.gameObject.tag == "Cube")
        {
            Debug.Log("HITT");
            //If the GameObject's name matches the one you suggest, output this message in the console
            //Destroy(hit.transform.parent.gameObject);
            //StartCoroutine(Respawn());
           
        }


    }

   /* IEnumerator Respawn()
    {

        cubeSetAmount = GameObject.FindGameObjectsWithTag("One");
        Debug.Log("Respawning");
        yield return new WaitForSeconds(5f);
        if(cubeSetAmount.Length <= gameData.CubeInstantiationLimits)
        SpawnCubeSet();
    }

    IEnumerator AutoRespawn()
    { 

        if (cubeSetAmount.Length < gameData.CubeInstantiationLimits)
        {
            Debug.Log(cubeSetAmount.Length);
            inQueue ++;
            yield return new WaitForSeconds(5 * inQueue);
            Debug.Log("spawning" + inQueue);
            SpawnCubeSet();
            cubeSetAmount = GameObject.FindGameObjectsWithTag("One");
           
        }
            
    }*/
}
