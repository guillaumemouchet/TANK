
/*
 * Title : Combat
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Combat : MonoBehaviourPunCallbacks
{   
    private void OnEnable()
    {
        Debug.Log("Start Combat");
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(CombatEventCode, null, raiseEventOptions, SendOptions.SendReliable);

        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        //GameObject tank = (GameObject)PhotonNetwork.LocalPlayer.TagObject;
        //TankController tankController = tank.GetComponent<TankController>();
        //tankController.ExecuteAction();
    }

    /***************************************************************\
     *                      Méthodes private                       *
    \***************************************************************/


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools

    private const int CombatEventCode = 33;

    // Components


}
