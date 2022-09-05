/*
 * Title : Game Setup 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : https://www.youtube.com/watch?v=onDorc3Qfn0 
 */
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetup : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Invoke("CreatePlayer", 1); // Appelle CreatePlayer() après 1 seconde
    }

    private void CreatePlayer()
    {
        if (TankController.LocalPlayerInstance == null)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TankBasic"), GameController.instance.spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}