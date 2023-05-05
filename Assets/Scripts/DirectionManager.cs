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
    [SerializeField]
    private GameObject m_otakuGalObj;
    [SerializeField]
    private GameObject m_olMajimekunObj;
    [SerializeField]
    private OLMajimekun m_oLMajimekun1;
    [SerializeField]
    private OLMajimekun m_olMajimekun2;

    public void WomanInteri()
    {       
        photonView.RPC(nameof(RPC_WomanInteri), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_WomanInteri()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Vector3 eulerRot = m_careerwomanInteriObj.transform.eulerAngles;
            m_careerwomanInteriObj.transform.eulerAngles = new Vector3(eulerRot.x, eulerRot.y, -180);
        }
        m_careerwomanInteriObj.SetActive(true);
        womanInteri1.StartAnimation();
        womanInteri2.StartAnimation();
        StartCoroutine(WomanInteriWaitCorotine());
    }

    private IEnumerator WomanInteriWaitCorotine()
    {
        yield return new WaitForSeconds(5);
        m_careerwomanInteriObj.SetActive(false);
    }

    public void OtakuGal()
    {
        photonView.RPC(nameof(RPC_OtakuGal), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_OtakuGal()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Vector3 eulerRot = m_otakuGalObj.transform.eulerAngles;
            m_otakuGalObj.transform.eulerAngles = new Vector3(eulerRot.x, eulerRot.y, -180);
        }
        m_otakuGalObj.SetActive(true);
    }

    public void OlMajimekun()
    {
        photonView.RPC(nameof(RPC_OlMajimekun), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_OlMajimekun()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Vector3 eulerRot = m_careerwomanInteriObj.transform.eulerAngles;
            m_careerwomanInteriObj.transform.eulerAngles = new Vector3(eulerRot.x, eulerRot.y, -180);
        }
        m_careerwomanInteriObj.SetActive(true);
        womanInteri1.StartAnimation();
        womanInteri2.StartAnimation();
        StartCoroutine(OlMajimekuunCorotine());
    }

    private IEnumerator OlMajimekuunCorotine()
    {
        yield return new WaitForSeconds(5);
        m_careerwomanInteriObj.SetActive(false);
    }
}
