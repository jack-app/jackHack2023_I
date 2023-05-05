using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Photon.Pun;

public class ChangeBoard : MonoBehaviourPun
{
    [SerializeField]
    private GameObject m_y0baseBoard;
    [SerializeField]
    private GameObject m_ylengthbaseBoard;
    [SerializeField]
    private GameObject m_y0ChangeBoard;
    [SerializeField]
    private GameObject m_ylengthchangeBoard;

    public void Change()
    {
        photonView.RPC(nameof(RPC_Change), RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void RPC_Change()
    {
        int y0lane = 0;
        int ylengthlane = 0;
        for (int x = 0; x < FieldData.FIELD_LENGTH; x++)
        {
            y0lane += FieldManager.Instance.GetPieceToField(x, 0);
            ylengthlane += FieldManager.Instance.GetPieceToField(x, FieldData.FIELD_LENGTH - 1);
        }
        if (y0lane == 0)
        {
            photonView.RPC(nameof(RPC_Y0Change), RpcTarget.AllViaServer);
        }
        if (ylengthlane == 0)
        {
            photonView.RPC(nameof(RPC_YLengthChange), RpcTarget.AllViaServer);
        }        
    }

    [PunRPC]
    private void RPC_Y0Change()
    {
        m_y0baseBoard.SetActive(false);
        m_y0ChangeBoard.SetActive(true);
    }

    [PunRPC]
    private void RPC_YLengthChange()
    {
        m_ylengthbaseBoard.SetActive(false);
        m_ylengthchangeBoard.SetActive(true);
    }
}
