using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private ScoreManager scoreManager;

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

        playerController.StartThrow();
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
        //playerController.StartThrow();
        Invoke(nameof(NextThrow), 3.0f);
    }

    void NextThrow()
    {
        if (scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"FrameDebugger: {scoreManager.currentFrame}, Throw: {scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());
            Debug.Log($"Current Score: {scoreManager.CalculateTotalScore()}");

            // Get the ball to the start position
            playerController.StartThrow();
        }
    }

    public int CalculateFallenPins()
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
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log($"Total Fallen Pins {count}");
        return count;
    }

    public void ResetAllPins()
    {
        foreach(Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

}
