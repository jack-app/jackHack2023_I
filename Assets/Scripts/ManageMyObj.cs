using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMyObj : MonoBehaviourPun
{
    public void DestroyMyObj()
    {
        photonView.RPC(nameof(RPC_DestroyMyObj), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_DestroyMyObj()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
