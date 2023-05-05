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
    [SerializeField]
    private GameObject m_otonaOnesanBanddmanObj;
    [SerializeField]
    private OtonaonesanBandoman m_otonaonesanBandoman1;
    [SerializeField]
    private OtonaonesanBandoman m_otonaonesanBandoman2;
    [SerializeField]
    private GameObject m_charaoOnesanObj;

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
        m_otakuGalObj.SetActive(true);
    }

    public void OlMajimekun()
    {
        photonView.RPC(nameof(RPC_OlMajimekun), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_OlMajimekun()
    {
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

    public void OtonaOnesanBanddman()
    {
        photonView.RPC(nameof(RPC_OtonaOnesanBanddman), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_OtonaOnesanBanddman()
    {
        m_otonaOnesanBanddmanObj.SetActive(true);
        m_otonaonesanBandoman1.StartAnimation();
        m_otonaonesanBandoman2.StartAnimation();
        StartCoroutine(OtonaOnesanBanddmanCorotine());
    }

    private IEnumerator OtonaOnesanBanddmanCorotine()
    {
        yield return new WaitForSeconds(5);
        m_otonaOnesanBanddmanObj.SetActive(false);
    }



    public void CharaoOnesan()
    {
        photonView.RPC(nameof(RPC_CharaoOnesan), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_CharaoOnesan()
    {
        m_charaoOnesanObj.SetActive(true);
    }
}
