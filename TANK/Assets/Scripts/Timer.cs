/*
 * Title : Timer 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source : 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            //Debug.Log("deltaTime " + Time.deltaTime);
            DisplayTime(timeValue);
        }
        else
        {
            timeValue = 0;
            isFinished = true;
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    public void ResetTimer()
    {
        timeValue = TIMER_SECONDS;
        isFinished = false;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroying timer");
    }

    private const float TIMER_SECONDS = 10f;
    public float timeValue;
    [SerializeField] private TMP_Text timeText;
    private bool isFinished = false;

}
