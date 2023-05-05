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
        // ˆø‚«•ª‚¯0, ‘¼AŸ‚Á‚½‚Ù‚¤‚Ì”Ô†“n‚·
        if (resultNum == 0)
        {
            // ˆø‚«•ª‚¯ˆ—
            m_resultText.text = "ˆø‚«•ª‚¯";
        }
        else if (resultNum ==  PhotonNetwork.LocalPlayer.ActorNumber)
        {
            // Ÿ‚Á‚½‚Ìˆ—
            m_resultText.text = "Ÿ‚¿!";
        }
        else 
        {
            // •‰‚¯‚½‚Ìˆ—
            m_resultText.text = "•‰‚¯...";
        }
        m_button.SetActive(true);
    }
}
