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
        // 引き分け0, 他、勝ったほうの番号渡す
        if (resultNum == 0)
        {
            // 引き分け処理
            m_resultText.text = "引き分け";
        }
        else if (resultNum ==  PhotonNetwork.LocalPlayer.ActorNumber)
        {
            // 勝った時の処理
            m_resultText.text = "勝ち!";
        }
        else 
        {
            // 負けた時の処理
            m_resultText.text = "負け...";
        }
        m_button.SetActive(true);
    }
}
