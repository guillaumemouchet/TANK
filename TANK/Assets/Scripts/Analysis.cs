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
        DefaultSettings();
        isOver = true;
    }

    private void DefaultSettings()
    {
        
        //Enlever les éléments de chaque TANKs (bouclier, buffs etc)

        //Retour à la phase de préparation
        happeningDone=false;
    }

    private void CheckHappening()
    {
       
    }

    private void CheckAlive()
    {

        foreach(Player player in PhotonNetwork.PlayerList)
        {
            //Get Life
            Debug.Log("Cant Get players life");
            //if player is dead --> spectator Mode
        }
    }

    private void CheckVictory()
    {
        //If all player of the same team are dead
        //Victory of the other team and end the Game
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools

    private bool happeningDone = false;
    [SerializeField] private Happening hp;
    private bool isOver = false;
}
