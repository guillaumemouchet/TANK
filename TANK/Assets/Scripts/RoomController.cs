/*
 * Title : Room Controller 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
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
    [SerializeField] private TMP_Text playerCount;
    void ClearPlayerListings()
    {
        for (int i = playersContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    private void ListPlayers()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log("PLAYER NAME :" + player.NickName);
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            PlayerButton tempButton = tempListing.GetComponent<PlayerButton>();
            tempButton.SetPlayer(player.NickName);
        }

        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers;

        if (PhotonNetwork.IsMasterClient && (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers))
        {
                startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
            Debug.Log("Not Ready to start yet");
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
