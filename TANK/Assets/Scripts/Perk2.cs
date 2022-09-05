/*
 * Title : Perk2.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk2 : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private void Start()
    {
        /*switch (togglePerk2.tag)
        {
            case "Shield":
                Shield();
                break;
        }*/
    }

    private void OnEnable()
    {
        Debug.Log("Perk2 enabled"); 
        switch (togglePerk2.tag)
        {
            case "Shield":
                shield = Instantiate(shieldObject, this.transform);
                shieldShield = (Shield)shield.GetComponent<Shield>();
                Shield();
                break;
        }
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        if (!lockedIn)
        {
            Debug.Log("Perk2 disabled");
            Destroy(shield);
        }
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    /***************************************************************\
     *                       Méthodes publics                      *
    \***************************************************************/

    public void LockIn()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                shieldShield.LockIn();
                lockedIn = true;
                break;
        }
    }
    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == CombatFinishedCode && lockedIn)
        {
            shieldShield.enabled = false;
            lockedIn = false;
            Destroy(this);
        }
    }

    public void Execute()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                shieldShield.Execute();
                break;
        }
    }


    /***************************************************************\
     *                       Méthodes private                      *
    \***************************************************************/

    private void Actions2()
    {

    }

    private void Shield()
    {
        Debug.Log("Shield() called in Perk2.cs");
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject shield;
    private Shield shieldShield;

    // Components
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Toggle togglePerk2;
    private bool lockedIn = false;

    // Codes
    private const int CombatFinishedCode = 34;
}