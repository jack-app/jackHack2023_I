using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PieceManager : MonoBehaviour
{
    GameObject prefabi;
    Vector3 Positioni;

    // ScriptableObjectのパスを指定（ScriptableObjectを右クリック>copy path取得できます。）
    string filePath = "Assets/New Piece Status Scriptable Object.asset";

    // テスト用にキーボードのスペースキーを押した時に関数を呼び出す
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PieceStatusScriptableObject pieceStatusScriptableObject = AssetDatabase.LoadAssetAtPath<PieceStatusScriptableObject>(filePath);
            CreateMyPieces(pieceStatusScriptableObject);
        }
#endif
    }

    public void CreateMyPieces(PieceStatusScriptableObject pieceStatusScriptableObject)
    {

        int listCount = pieceStatusScriptableObject.list.Count;//Listの要素数の取得 
        Debug.Log("listCount:" + listCount);
        for (int i = 0; i < listCount; i++)
        {
            prefabi = pieceStatusScriptableObject.list[i].prefab;//prefabの取得
            Positioni = pieceStatusScriptableObject.list[i].Position;//Positionの取得

            Debug.Log("prefab:" + prefabi);
            Debug.Log("Positon:" + Positioni);

            // 新しいオブジェクトを生成する
            GameObject newObjecti = Instantiate(prefabi, Positioni, Quaternion.identity);

        }

    }

}
