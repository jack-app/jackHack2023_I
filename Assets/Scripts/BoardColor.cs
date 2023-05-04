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

        
        if (Mathf.Abs(pos.x) > 10 | Mathf.Abs(pos.y)> 10)//もし盤面の外だったら
        {
            GetComponent<Renderer>().material.color = Color.red;//ボードを赤色にする
            this.tag = "NotBoard";//タグをボードではなくす
        }
        else//もし盤面の中だったら
        {
            GetComponent<Renderer>().material.color = Color.green;//ボードを緑色にする
            this.tag = "Board";//タグをボードにする
        }
    }
}