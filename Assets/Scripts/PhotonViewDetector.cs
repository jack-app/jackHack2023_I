using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonViewDetector : MonoBehaviour
{
    public bool IsMyObject(PhotonView photonView)
    {
        if (!PhotonNetwork.InRoom) return true;
        if (photonView.IsMine)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
