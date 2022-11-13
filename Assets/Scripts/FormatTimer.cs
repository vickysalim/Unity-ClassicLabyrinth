using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormatTimer : MonoBehaviour
{
    public static string GetTimer(float deltaTime) {
        float minutes = Mathf.FloorToInt(deltaTime / 60);
        float seconds = deltaTime % 60;

        string timeInMS = (minutes < 1 ? "" : minutes + ":") + (seconds < 10 ? "0" + seconds.ToString("F2") : seconds.ToString("F2"));

        return timeInMS;
    }
}
