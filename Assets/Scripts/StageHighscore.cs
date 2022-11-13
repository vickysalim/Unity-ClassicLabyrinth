using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageHighscore : MonoBehaviour
{
    [SerializeField] TMP_Text stageTimeText;
    [SerializeField] int stageNumber;
    void Start()
    {
        string stageKey = "Stage" + stageNumber;
        if (PlayerPrefs.HasKey(stageKey))
        {
            stageTimeText.text = "Best Time: " + FormatTimer.GetTimer(PlayerPrefs.GetFloat(stageKey));
        }
        else
        {
            stageTimeText.text = "Best Time: -";
        }
    }
}
