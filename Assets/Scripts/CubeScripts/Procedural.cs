using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{

    bool turnBack = false;
    private Vector3 position;
    public ManagerData gameData;
    [SerializeField] private float cubeSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        Debug.Log(gameData.CubeSpeed + " CB "  + cubeSpeed);
        if(gameData.CubeSpeed != 0)
        {
            cubeSpeed = gameData.CubeSpeed;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x >= position.x + 5)
        {
            turnBack = true;
        }
        else if (transform.position.x <= position.x - 5)
        {
            turnBack = false;
        }

       
        if (turnBack)
        {
            transform.Translate((Vector3.left  * Time.deltaTime) * cubeSpeed);
        }
        else { 
            transform.Translate((Vector3.right  * Time.deltaTime) * cubeSpeed); 
        }
        
    }

    public void UpdateCubeSpeed(float newCubeSpeed)
    {
        cubeSpeed = newCubeSpeed;
    }
}
