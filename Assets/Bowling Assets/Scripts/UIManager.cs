using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform frameHolder;
    [SerializeField] private GameObject messageUIStrike;
    [SerializeField] private GameObject messageUISpare;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TMP_Text scoreText;

    private FrameUI[] frames;

    // Start is called before the first frame update
    void Start()
    {
        ResetFrameUI();
        messageUIStrike.SetActive(false);
        messageUISpare.SetActive(false);
        gameOverUI.SetActive(false);
    }

    // Reset FrameUI children objects under the FrameHolder Transform
    public void ResetFrameUI() 
    {
        frames = new FrameUI[frameHolder.childCount];
        for (int i=0; i < frameHolder.childCount; i++)
        {
            frames[i] = frameHolder.GetChild(i).GetComponent<FrameUI>();
            frames[i].SetFrame(i + 1); //+1 is important because we index from 0 but the frames start at 1

        }
    }

    public void SetFrameValue(int frame, int throwNumber, int score)
    {
        frames[frame - 1].UpdateScore(throwNumber, score);// -1 is because current frame position is indexed at 1 but the array indexes at 0

    }

    public void SetFrameTotal(int frame, int score)
    {
        frames[frame].UpdateTotal(score); // we are showing the score in the next frame
    }

    public void ShowStrike()
    {
        messageUIStrike.SetActive(true);
        Invoke(nameof(HideStrike), 2.0f);
    }

    public void HideStrike()
    {
        messageUIStrike.SetActive(false);
    }

    public void ShowSpare()
    {
        messageUISpare.SetActive(true);
        Invoke(nameof(HideSpare), 2.0f);
    }

    public void HideSpare()
    {
        messageUISpare.SetActive(false);
    }

    public void ShowGameOver(int totalScore)
    {
        gameOverUI.SetActive(true);
        scoreText.text = totalScore.ToString();
    }
}
