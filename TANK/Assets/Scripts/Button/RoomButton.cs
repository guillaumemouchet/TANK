/*
 * Title : Room Button 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : https://www.youtube.com/watch?v=onDorc3Qfn0 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class RoomButton : MonoBehaviour
{

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/


    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName); 
    }

    public void SetRoom(string nameInput, int sizeInput, int countInput)
    {
        roomName = nameInput;
        roomSize = sizeInput;
        playerCount = countInput;
        nameText.text = nameInput;
        sizeText.text = countInput + "/" + sizeInput;
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text sizeText;

    private string roomName;
    private int roomSize;
    private int playerCount;
}
