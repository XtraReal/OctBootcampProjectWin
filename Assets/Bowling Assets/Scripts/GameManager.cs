using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        CalculateFallenPins();
        StartGame();
    }

    public void StartGame()
    {
        isGamePlaying = true;
        SetNextThrow();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isGamePlaying == false && Input.GetKeyUp(KeyCode.X))
        //{
        //    StartGame();
        //}
    }

    public void SetNextThrow()
    {
        // Get the ball to the start position
        CalculateFallenPins();
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

    public void ResetAllPins()
    {
        foreach(Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

}
