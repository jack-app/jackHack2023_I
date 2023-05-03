using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonQuickMatching : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int m_maxPlayers = 2;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // �����_���ȃ��[���ɎQ������
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // �Q���ł��郋�[�����Ȃ�������V�K�Ń��[�����쐬����
        // ���[���̎Q���l����ݒ肷��
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)m_maxPlayers;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }
}
