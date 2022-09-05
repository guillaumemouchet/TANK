/*
 * Title : Analyse
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.SceneManagement;

public class Analysis : MonoBehaviour
{

    private void OnEnable()
    {
        isOver = false;
        
        StartAnalyse();
    }

    public bool IsOver()
    {
        return isOver;
    }

    private void StartAnalyse()
    {
        //Controler l'état de chaque joueur
        CheckAlive();
        CheckVictory();
        CheckHappening();
        if (analysisTwo)
        {
            DefaultSettings();
            analysisTwo = false;
        }else
        {
            analysisTwo=true;
        }
        isOver = true;
    }

    private void DefaultSettings()
    {
        //Enlever les éléments de chaque TANKs (bouclier, buffs etc)
        
        UnityEngine.Object[] shieldtab = FindObjectsOfType(typeof(Shield));
        foreach (Shield shield in shieldtab)
        {
            DestroyImmediate(shield.gameObject);
        }

    }

    private void CheckHappening()
    {
       
    }

    private void CheckAlive()
    {

        UnityEngine.Object[] tankTab = FindObjectsOfType(typeof(TankController));
        Debug.Log("CheckAlive");
        foreach (TankController tank in tankTab)
        {
            if(tank.CompareTag("Tank"))
            {//Get Life
                if (tank.Gethealth()<0)
                {
                    Debug.Log("Player dead");
                    //if player is dead --> spectator Mode
                    tank.gameObject.SetActive(false);

                }
            }
            
        }
    }

    private void CheckVictory()
    {
        //If all player of the same "team" are dead
        int i = 0;
        UnityEngine.Object[] tankTab2 = FindObjectsOfType(typeof(TankController));
        Debug.Log("CheckAlive");
        foreach (TankController tank in tankTab2)
        {
            if (tank.CompareTag("Tank"))
            {//Get Life
                if (tank.Gethealth() < 0)
                {
                    i++;
                }
            }

        }
        if (i<2)
        {
            endGamePanel.SetActive(true);
            analysisPanel.SetActive(false);
            gameEnded = true;
            Invoke("CompleteLevel", 5f);
        }
        //Victory of the other team and end the Game
    }
    private void CompleteLevel()
    {
        Debug.Log("ferme l'appli");
        Application.Quit();
    }

    public bool GameEnded()
    {
        return gameEnded;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool analysisTwo = false;
    private bool gameEnded = false;
    [SerializeField] private Happening hp;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject analysisPanel;
    private bool isOver = false;
}
