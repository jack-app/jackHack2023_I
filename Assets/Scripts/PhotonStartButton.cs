using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonStartButton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject m_button;

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            m_button.SetActive(true);
        }
    }

    public void DisableButton()
    {
        m_button.SetActive(false);
    }
}
