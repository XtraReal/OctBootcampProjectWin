using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int numberVariable; //Variable Declaration
    public bool isDoingSomething = false;   //Variable initialization
    public float speed = 10.0f;
    public string name = "Sean";

    public Transform cubeTransform; //This is a reference type, so it can reference other GameObjects
    public Vector3 position;
    public Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        isDoingSomething = true; // Variable Assignment
        Debug.Log("Hello from Start");
        Debug.Log("The new variables are: " + this);

        cubeTransform.position = position;

        //cubeTransform.rotation = rot;
        
        //cubeTransform.position.x = -4;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The number variable is: " + numberVariable);
        //cubeTransform.Translate(Vector3.forward * Time.deltaTime);
        if(isDoingSomething == true)
        {
            cubeTransform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            return;
        }
    }
}
