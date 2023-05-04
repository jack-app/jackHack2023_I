using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ResultManager : MonoBehaviourPun
{
    [SerializeField]
    private TextMeshProUGUI m_resultText;

    [SerializeField]
    private GameObject m_button;

    public void ShowResult(int resultNum)
    {
        photonView.RPC(nameof(RPC_ShowResult), RpcTarget.AllViaServer, resultNum);
    }

    [PunRPC]
    private void RPC_ShowResult(int resultNum)
    {
        // ��������0, ���A�������ق��̔ԍ��n��
        if (resultNum == 0)
        {
            // ������������
            m_resultText.text = "��������";
        }
        else if (resultNum ==  PhotonNetwork.LocalPlayer.ActorNumber)
        {
            // ���������̏���
            m_resultText.text = "����!";
        }
        else 
        {
            // ���������̏���
            m_resultText.text = "����...";
        }
        m_button.SetActive(true);
    }
}
