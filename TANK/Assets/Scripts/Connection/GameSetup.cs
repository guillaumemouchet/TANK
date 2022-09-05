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

    void Start()
    {
        CreatePlayer();
    }
    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void CreatePlayer()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            int index = 0;
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (p == PhotonNetwork.LocalPlayer)
                {
                    Debug.Log("New Player created");
                    Debug.Log(index);
                    p.TagObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TankBasic"), GameController.instance.spawnPoints[index].position, Quaternion.identity);
                    DontDestroyOnLoad((Object)p.TagObject);
                }
                else
                {
                    index++;
                }
            }
        }
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/



    /***************************************************************\
    *                      Attributes private                     *
    \***************************************************************/
}