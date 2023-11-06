using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;


    private int totalScore;

    public int currentThrow { get; private set; }
    public int currentFrame { get; private set; }

    private int[] frames = new int[10];

    private bool isSpare = false;
    private bool isStrike = false;

    // Set value for our frame score each time the ball is thrown
    public void SetFrameScore(int score)
    {
        if(currentThrow == 1)
        {
            frames[currentFrame - 1] += score; // Setting the right frame index and
                                                // adding the score value from the
                                                // parameter passed
            // Parallel process to chek spare
            if (isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            //-------------------------------

            // Checking if this is a strike
            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++; // Wait for Ball 2

                }
                else
                {
                    isStrike = true;
                    currentFrame++; // Move to next frame since full marks obtained
                }

                // TODO: GameManage to Reset Pins
            }
            else
            {
                currentThrow++; //Wait for BALL 2
            }

            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
