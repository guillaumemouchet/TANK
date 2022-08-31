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

public class GameSetup : MonoBehaviour
{
    public int index = 0;

    void Start()
    {
        CreatePlayers();
    }

    public void CreatePlayers()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (p != PhotonNetwork.LocalPlayer)
                {
                    index++;
                }
            }
            Debug.Log("New Player created");
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TankBasic"), GameController.instance.spawnPoints[index++].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}