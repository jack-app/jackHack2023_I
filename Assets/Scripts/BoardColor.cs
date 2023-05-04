using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        if (Mathf.Abs(pos.x) > 10 || Mathf.Abs(pos.y) > 10)//もし盤面の外だったら
        {
            GetComponent<Renderer>().material.color = Color.red;//ボードを赤色にする
            this.tag = "NotBoard";//タグをボードではなくす
        }
        else//もし盤面の中だったら
        {
            // 通信対戦中のみ
            if (PhotonNetwork.InRoom)
            {
                Vector2Int vec2 = FieldManager.Instance.ConvertRealPosToArrayPos(pos);
                // このボードの上に自分のコマがあったら
                if (FieldManager.Instance.GetPieceToField(vec2.x, vec2.y) ==  PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    GetComponent<Renderer>().material.color = Color.red;//ボードを赤色にする
                    this.tag = "NotBoard";//タグをボードではなくす
                    return;
                }
            }
            GetComponent<Renderer>().material.color = Color.green;//ボードを緑色にする
            this.tag = "Board";//タグをボードにする
        }
    }


}