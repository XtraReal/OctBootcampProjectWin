using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Pin[] pins;

    // Start is called before the first frame update
    void Start()
    {
        CalculateFallenPins();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNextThrow()
    {
        // Get the ball to the start position
        playerController.StartThrow();
    }

    public void CalculateFallenPins()
    {
        for (int i=0; i < pins.Length; i++)
        {
            Debug.Log("Loop Number: " + i);
        }
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
            }
        }
    }
}
