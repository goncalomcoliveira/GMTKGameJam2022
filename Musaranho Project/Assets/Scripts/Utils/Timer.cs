using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //remaining amount of time in the timer
    public float remainingTime = 50f;

    //timer UI element
    public TMP_Text timerText;

    //declare remaining seconds and minutes
    int seconds, minutes;

    void Update()
    {
        //decrease temaining time
        if (remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else {
            remainingTime = 0;
            //Debug.Log("Timer Done.");
        }

        //calculate remaining seconds and minutes
        seconds = Mathf.FloorToInt(remainingTime % 60);
        minutes = Mathf.FloorToInt(remainingTime / 60);

        //present the remaining time in the desired syntax
        if (remainingTime <= 60)
            timerText.text = seconds.ToString();
        else if (seconds < 10)
            timerText.text = minutes.ToString() + ":0" + (seconds).ToString();
        else
            timerText.text = minutes.ToString() + ":" + (seconds).ToString();
 
    }
}