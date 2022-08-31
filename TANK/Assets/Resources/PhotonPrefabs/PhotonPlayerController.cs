using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPlayerController : MonoBehaviour
{
    public static GameObject localPlayerInstance;
    public PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Awake()
    {
        if(pv.IsMine)
        {
            localPlayerInstance = this.gameObject;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && pv.IsMine)
        {
            Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is dep");
            transform.position = Vector2.zero;
        }
    }
}
