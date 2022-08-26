/*
 * Title : Room Controller 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : https://www.youtube.com/watch?v=onDorc3Qfn0 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField] private int multiPlayerSceneIndex;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject roomPanel;
    [SerializeField] private GameObject startButton;
    [SerializeField] private Transform playersContainer;
    [SerializeField] private GameObject playerListingPrefab;
    [SerializeField] private TMP_Text roomNameDisplay;
    [SerializeField] private TMP_InputField roomSize;
    void ClearPlayerListings()
    {
        for (int i = playersContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    /*void ListPLayers()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
            tempText.text = player.NickName;
        }
    }*/
    private void ListPlayers()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log("PLAYER NAME :" + player.NickName);
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            /*if(PhotonNetwork.PlayerList!= null)
            {
                tempIndex = PhotonNetwork.PlayerList.FindIndex(ByName(player.NickName));
            }*/
            PlayerButton tempButton = tempListing./*transform.GetChild(0).*/GetComponent<PlayerButton>();
            tempButton.SetPlayer(player.NickName);
        }
    }
    static System.Predicate<Player> ByName(string name)
    {
        return delegate (Player player)
        {
            return player.NickName == name;
        };
    }
    public override void OnJoinedRoom()
    {
        roomPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient && (PhotonNetwork.PlayerList.Length==int.Parse(roomSize.text)))
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
            Debug.Log("Not Master");
        }
        ClearPlayerListings();
        ListPlayers();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        ClearPlayerListings();
        ListPlayers();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        ClearPlayerListings();
        ListPlayers();
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
    }


    public void startGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel(multiPlayerSceneIndex);
        }
    }

    IEnumerator rejoinLobby()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.JoinLobby();
    }

    public void BackOnClick()
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        StartCoroutine(rejoinLobby());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
