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
    private UIManager uiManager;

    [SerializeField]
    private Pin[] pins;

    [SerializeField]
    private Camera mainCam, closeUpCam;

    

    private bool isGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        //CalculateFallenPins();
        closeUpCam.enabled = false;
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
        Invoke(nameof(NextThrow), 3.0f);

    }

    void NextThrow()
    {
        int fallenPins = CalculateFallenPins();
        scoreManager.SetFrameScore(fallenPins);
        if (scoreManager.currentFrame == 0)
        {
            uiManager.ShowGameOver(scoreManager.CalculateTotalScore());
            //Debug.Log($"Game over {scoreManager.CalculateTotalScore()}");
            return;
        }
        //else
        //{
        //    Debug.Log($"FrameDebugger: {scoreManager.currentFrame}, Throw: {scoreManager.currentThrow}");
        //    scoreManager.SetFrameScore(CalculateFallenPins());
        //    Debug.Log($"Current Score: {scoreManager.CalculateTotalScore()}");

        //    // Get the ball to the start position
        //    playerController.StartThrow();
        //}

        // Calculate frame total for UI
        int frameTotal = 0;
        for (int i=0; i<scoreManager.currentFrame-1; i++)
        {
            frameTotal += scoreManager.GetFrameScores()[i];
            uiManager.SetFrameTotal(i, frameTotal);
        }

        // Switch back to main Camera
        SwitchCam();

        // Get the ball to the start position for throwing
        playerController.StartThrow();
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
            if (pin.isFallen && pin.gameObject.activeSelf)
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

    public void SwitchCam()
    {
        mainCam.enabled = !mainCam.enabled;
        closeUpCam.enabled = !closeUpCam.enabled;
    }
}
