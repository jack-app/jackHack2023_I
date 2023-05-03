using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonQuickMatching : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // ランダムなルームに参加する
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 参加できるルームがなかったら新規でルームを作成する
        // ルームの参加人数を設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }
}
