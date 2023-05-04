using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DirectionManager : MonoBehaviourPun
{
    [SerializeField]
    private GameObject m_careerwomanInteriObj;
    [SerializeField]
    private CareerWomanInteri womanInteri1;
    [SerializeField]
    private CareerWomanInteri womanInteri2;

    public void WomanInteri()
    {       
        photonView.RPC(nameof(RPC_WomanInteri), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_WomanInteri()
    {
        m_careerwomanInteriObj.SetActive(true);
        womanInteri1.StartAnimation();
        womanInteri2.StartAnimation();
        StartCoroutine(WaitCorotine());
    }

    private IEnumerator WaitCorotine()
    {
        yield return new WaitForSeconds(5);
        m_careerwomanInteriObj.SetActive(false);
    }
}
