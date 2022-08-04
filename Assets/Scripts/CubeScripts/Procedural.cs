using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public static Procedural SharedProcedural;
    bool turnBack = false;
    private Vector3 position;
    public ManagerData gameData;
    [SerializeField] private float cubeSpeed = 1;
    float xPos;
    float zPos;


    // Start is called before the first frame update
    void Start()
    {

        xPos = Random.Range(-40.0f, 40.0f);
        zPos = Random.Range(-40.0f, 40.0f);
      
   
        position = new Vector3(xPos, 1f, zPos);
        transform.position = position;
      
        if(gameData.CubeSpeed != 0)
        {
            cubeSpeed = gameData.CubeSpeed;
        }
       
    }

    public void NewCords()
    {
        xPos = Random.Range(-40.0f, 40.0f);
        zPos = Random.Range(-40.0f, 40.0f);
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
