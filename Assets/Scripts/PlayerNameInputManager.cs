using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInputManager : MonoBehaviour
{
 public void SetPalyerName(string PlayerName)
    {
        if (string.IsNullOrEmpty(PlayerName))
        {
            Debug.Log("Player Name is empty");
            return;
        }
        PhotonNetwork.NickName = PlayerName;

    }
}
