using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
