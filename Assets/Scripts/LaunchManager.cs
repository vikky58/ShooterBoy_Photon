using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{

    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;


    #region Unity Methods

    private void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }


    #endregion



    #region Public Methods
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            EnterGamePanel.SetActive(false);
            ConnectionStatusPanel.SetActive(true);
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    #endregion


    #region Photo CallBacks
    public override void OnConnectedToMaster()
    {
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);

        Debug.Log(PhotonNetwork.NickName + "Connected to photon Server");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to the internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " ~ Joined ~ " + PhotonNetwork.CurrentRoom.Name + " ~ "+ PhotonNetwork.CurrentRoom.PlayerCount);
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer + " ~  Joined  ~ " + PhotonNetwork.CurrentRoom.Name + " ~ " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer + " ~ Leave ~ " + PhotonNetwork.CurrentRoom.Name + " ~ " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion

    #region
    private void CreateAndJoinRoom()
    {
        string randoroom = "Room" + Random.Range(0, 1000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(randoroom,roomOptions);
    }
    #endregion




}
