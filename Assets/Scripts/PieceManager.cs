using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    GameObject prefabi;
    Vector3 positioni;

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
            positioni = pieceStatusScriptableObject.list[i].Position;//Positionの取得

            Debug.Log("prefab:" + prefabi);
            Debug.Log("Positon:" + positioni);

            // 新しいオブジェクトを生成する
            // 通信対戦の場合
            if (PhotonNetwork.InRoom)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Instantiate(prefabi.name, positioni, Quaternion.identity);
                }
                else
                {
                    positioni = Player2Transform.ConvertPosition(positioni);
                    PhotonNetwork.Instantiate(prefabi.name, positioni, new Quaternion(0, 0, 1, 0));
                }
            }
            // それ以外
            else
            {
                GameObject newObjecti = Instantiate(prefabi, positioni, Quaternion.identity);
            }
        }
    }
}
