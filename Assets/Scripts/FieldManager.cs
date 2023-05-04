using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class FieldManager : MonoBehaviourPun
{
    public static FieldManager Instance { get; private set; }

    private int[,] m_field = new int[FieldData.FIELD_LENGTH, FieldData.FIELD_LENGTH]; // �Ֆʂ̏�� 0:�����Ȃ��A1:�z�X�g�A2:�Q�X�g

    private void Awake()
    {
        Instance = this;
    }

    public Vector2Int ConvertRealPosToArrayPos(Vector3 pos)
    {
        int x = (int)Mathf.Round(pos.x) / FieldData.FIELD_REAL_LENGTH + FieldData.FIELD_LENGTH / 2;
        int y = (int)Mathf.Round(pos.y) / FieldData.FIELD_REAL_LENGTH + FieldData.FIELD_LENGTH / 2;
        return new Vector2Int(x, y);
    }

    public int GetPieceToField(int x, int y)
    {
        // ���͒l���͈͊O�Ȃ�-1��Ԃ�
        if (x < 0 || y < 0 || x >= FieldData.FIELD_LENGTH || y >= FieldData.FIELD_LENGTH)
        {
            return 0;
        }
        return m_field[x, y];
    }

    public void SetPieceToField(int num, int x, int y)
    {
        photonView.RPC(nameof(RPC_SetPieceToField), RpcTarget.AllViaServer, num , x, y);
    }

    [PunRPC]
    private void RPC_SetPieceToField(int num, int x, int y)
    {
        m_field[x, y] = num;
        Debug.Log(x + "," + y + "," + num);
    }

    public void RemovePieceToField(int x, int y)
    {
        photonView.RPC(nameof(RPC_RemovePieceToField), RpcTarget.AllViaServer, x, y);
    }

    [PunRPC]
    private void RPC_RemovePieceToField(int x, int y)
    {
        m_field[x, y] = 0;
    }

    public bool CheckBattle(int x, int y)
    {
        // ����̃R�}���z�u����Ă�����
        if (GetPieceToField(x, y) == PhotonNetwork.LocalPlayer.GetNextFor(PhotonNetwork.LocalPlayer.ActorNumber).ActorNumber)
        {
            return true;
        }
        return false;
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}
