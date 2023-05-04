using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonPlaySE : MonoBehaviourPun
{
    [SerializeField]
    private AudioSource m_AudioSource;

    public void PlaySE()
    {
        photonView.RPC(nameof(RPC_PlaySE), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_PlaySE()
    {
        m_AudioSource.Play();
    }
}
