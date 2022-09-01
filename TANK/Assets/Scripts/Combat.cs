
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

public class Combat : MonoBehaviour
{   
    private void OnEnable()
    {
        Debug.Log("Start Combat");
        Dictionary<int, Player> playersDict = PhotonNetwork.CurrentRoom.Players;
        foreach (KeyValuePair<int, Player> keyVal in playersDict)
        {
            if (keyVal.Value.IsLocal)
            {
                GameObject playerTank = (GameObject)keyVal.Value.TagObject;
                tankController = playerTank.GetComponent<TankController>();
            }
        }

        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        ExecuteAction();

    }

    private void Update()
    {
        
    }

    /***************************************************************\
     *                      Méthodes private                       *
    \***************************************************************/

    private void ExecuteAction()
    {
        //Debug.Log("Execute action");
        tankController.ExecuteAction();
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    
    // Tools


    // Components
    private TankController tankController;
}
