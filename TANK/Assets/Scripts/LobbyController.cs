/*
 * Title : Lobby Controller 
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
using UnityEngine.EventSystems;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject lobbyConnectButton;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_InputField TMP_roomName;
    [SerializeField] private TMP_InputField TMP_roomSize;
    [SerializeField] private GameObject helpPanel;
    private string roomName;
    private int roomSize;

    private List<RoomInfo> roomListings;
    [SerializeField] private Transform roomsContainer;
    [SerializeField] private GameObject roomListingPrefab;

    public void Start()
    {
        playerNameInput.Select();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive(true);
        roomListings = new List<RoomInfo>();

        if (PlayerPrefs.HasKey("NickName"))
        {
            if (PlayerPrefs.GetString("NickName") == "")
            {
                PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        }
        playerNameInput.text = PhotonNetwork.NickName;
    }
    public void PlayerNameUpdate(string nameInput)
    {

        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName", nameInput);
    }

    public void JoinLobbyOnClick()
    {
        if (!string.IsNullOrWhiteSpace(PhotonNetwork.NickName))
        {
            mainPanel.SetActive(false);
            lobbyPanel.SetActive(true);
        }else
        {
            PhotonNetwork.JoinLobby();
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
            PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);
            playerNameInput.text = PhotonNetwork.NickName;
        }
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        ClearRoomListings();
        int tempIndex;
        foreach (RoomInfo room in roomList)
        {
            if (roomListings != null)
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            }
            else
            {
                tempIndex = -1;
            }
            if (tempIndex != -1)
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomsContainer.GetChild(tempIndex).gameObject);
            }
            if (room.PlayerCount > 0)
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }

    static System.Predicate<RoomInfo> ByName(string name)
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    private void ListRoom(RoomInfo room)
    {
        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    void ClearRoomListings()
    {
        for (int i = roomsContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(roomsContainer.GetChild(i).gameObject);
        }
    }

    public void OnRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
    }

    public void OnRoomSizeChanged(string sizeIn)
    {
        if (!string.IsNullOrWhiteSpace(sizeIn))
        {
            if (sizeIn.Length > 0 && (sizeIn[0] == '-' || sizeIn[0] == '0'))
            {
                TMP_roomSize.text = sizeIn.Remove(0, 1) + '1';

            }
            
                roomSize = int.Parse(TMP_roomSize.text);

            
        }

    }

    public void CreateRoom()
    {
        if (!(string.IsNullOrWhiteSpace(TMP_roomName.text) || string.IsNullOrWhiteSpace(TMP_roomSize.text)))
        {
            Debug.Log("Creating room now");
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
            PhotonNetwork.CreateRoom(roomName, roomOps);
        }else
        {
            Debug.Log("Missing Arguments");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create new room, name already taken");
    }

    public void MatchMakingCancel()
    {
        mainPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }

    public void QuitGameOnClick()
    {
        Application.Quit();
    }

    public void DisplayHelp()
    {
        helpPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void BackFromHelp()
    {
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
