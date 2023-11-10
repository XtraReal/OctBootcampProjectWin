using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameManager gameManager;

    bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin") && !hasCollided)
        {
            hasCollided = true;
            Debug.Log("The object we collided with is " + collision.gameObject.name);
            //collision.gameObject.CompareTag("Pin");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pit"))
        {
            gameManager.SetNextThrow();
            // Destroy Ball gameObject
            Destroy(gameObject);
        }
        else if(other.CompareTag("CloseUpCam"))
        {
            // Change Camera Position
            gameManager.SwitchCam();
        }
        
    }
}
