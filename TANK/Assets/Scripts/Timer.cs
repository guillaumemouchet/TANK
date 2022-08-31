/*
 * Title : Timer 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source : 
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeValue = 60;
    public TMP_Text timeText;
    private bool isFinished = false;

    [SerializeField] private GameObject preparationPanel;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }else
        {
            timeValue = 0;
            //Combat phase
            Debug.Log("Fin de la préparation");
            isFinished = true;
        }
        DisplayTime(timeValue);

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
}
