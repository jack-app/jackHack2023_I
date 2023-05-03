using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonRoomData : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;

    [SerializeField]
    private GameObject m_startButton;

    [SerializeField]
    private string m_gameSceneName = "Main";

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
            if (PhotonNetwork.IsMasterClient)
            {
                m_startButton.SetActive(true);
            }
        }
    }

    public void GameStartButton()
    {
        photonView.RPC(nameof(RPC_GameStart), RpcTarget.AllViaServer);
    }

    [PunRPC]
    public void RPC_GameStart()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadSceneAsync(m_gameSceneName);
    }
}
