using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.Cockpit;

public class PhotonRoomData : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;

    [SerializeField]
    private GameObject m_startButton;

    [SerializeField]
    private GameObject m_waitText;

    [SerializeField]
    private GameObject m_matchingText;

    [SerializeField] 
    private GameObject m_matchedText;

    [SerializeField]
    private string m_gameSceneName = "Main";

    [SerializeField]
    private GameObject m_backButton;

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
            m_TextMeshPro.text = "ÉãÅ[ÉÄêlêî: " + PhotonNetwork.PlayerList.Length.ToString();
            m_backButton.SetActive(true);
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                m_matchingText.SetActive(false);
                m_matchedText.SetActive(true);
                if (PhotonNetwork.IsMasterClient)
                {
                    m_startButton.SetActive(true);
                }
                else
                {
                    m_waitText.SetActive(true);
                }
            }
            else
            {
                m_matchingText.SetActive(true);
                m_matchedText.SetActive(false);
                m_startButton.SetActive(false);
                m_waitText.SetActive(false);
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
