using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text bestTimeText;

    [SerializeField] PhoneGravity ball;

    [SerializeField] float timer;

    public AudioSource audioSource;
    public AudioClip victoryAudio;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!ball.IsEnteringHole)
            timer += Time.deltaTime;

        string timeInString = FormatTimer.GetTimer(timer);
        timerText.text = timeInString;

        if (ball.IsEnteringHole && gameOverPanel.activeInHierarchy == false)
        {
            audioSource.PlayOneShot(victoryAudio);

            gameOverPanel.SetActive(true);
            int sceneNumber = int.Parse((SceneManager.GetActiveScene().name).Split("Stage")[1]);
            gameOverText.text = "Stage " + sceneNumber + ": " + timeInString;

            string stageKey = SceneManager.GetActiveScene().name;

            if (PlayerPrefs.HasKey(stageKey))
            {
                if (timer < PlayerPrefs.GetFloat(stageKey))
                    PlayerPrefs.SetFloat(stageKey, timer);
            }
            else
            {
                PlayerPrefs.SetFloat(stageKey, timer);
            }

            Debug.Log(stageKey);

            bestTimeText.text = "Best: " + FormatTimer.GetTimer(PlayerPrefs.GetFloat(stageKey));
        }   
    }

    public void BackToMainMenu()
    {
        SceneLoader.Load("MainMenu");
    }

    public void Replay()
    {
        SceneLoader.ReloadStage();
    }

    public void PlayNext()
    {
        SceneLoader.LoadNextStage();
    }
}
