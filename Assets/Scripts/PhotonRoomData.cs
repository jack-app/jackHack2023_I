using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class PhotonRoomData : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;

    private bool m_joinedRoom = false;

    public override void OnJoinedRoom()
    {
        m_joinedRoom=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_joinedRoom)
        {
            m_TextMeshPro.text = "RoomMember: " + PhotonNetwork.PlayerList.Length.ToString();
        }
    }
}
