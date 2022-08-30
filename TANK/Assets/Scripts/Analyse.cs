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

public class Analyse : MonoBehaviour
{
    private bool happeningDone = false;
    private Happening hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Happening>();

        
    }

    void Update()
    {
        
    }

    private void StartAnalyse()
    {
        //Controler l'état de chaque joueur
        CheckAlive();
        CheckVictory();
        CheckHappening();
        DefaultSettings();
    }

    private void DefaultSettings()
    {
        
        //Enlever les éléments de chaque TANKs (bouclier, buffs etc)

        //Retour à la phase de préparation
        happeningDone=false;
    }

    private void CheckHappening()
    {
       if(!happeningDone)
        {
            hp.StartHappening();
            happeningDone=true;
        }
    }

    private void CheckAlive()
    {
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            //Get Life
            //if player is dead --> spectator Mode
        }
    }

    private void CheckVictory()
    {
        //If all player of the same team are dead
        //Victory of the other team and end the Game
    }

}
