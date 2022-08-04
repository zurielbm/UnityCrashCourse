using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public ManagerData gameData;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (hit.collider.gameObject.tag == "Cube")
        {
            Debug.Log("HITT");
            PoolSpawning.SharedInstance.pool.Release(hit.collider.transform.parent.gameObject);
            
            StartCoroutine(Respawn());
        }

    }

    IEnumerator Respawn()
    {

        yield return new WaitForSeconds(2f);
        PoolSpawning.SharedInstance.pool.Get();
    }
}
