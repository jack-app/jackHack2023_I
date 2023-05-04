using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    GameObject prefabi;
    Vector3 positioni;

    // ScriptableObject�̃p�X���w��iScriptableObject���E�N���b�N>copy path�擾�ł��܂��B�j
    string filePath = "Assets/New Piece Status Scriptable Object.asset";

    // �e�X�g�p�ɃL�[�{�[�h�̃X�y�[�X�L�[�����������Ɋ֐����Ăяo��
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

        int listCount = pieceStatusScriptableObject.list.Count;//List�̗v�f���̎擾 
        Debug.Log("listCount:" + listCount);
        for (int i = 0; i < listCount; i++)
        {
            prefabi = pieceStatusScriptableObject.list[i].prefab;//prefab�̎擾
            positioni = pieceStatusScriptableObject.list[i].Position;//Position�̎擾

            Debug.Log("prefab:" + prefabi);
            Debug.Log("Positon:" + positioni);

            // �V�����I�u�W�F�N�g�𐶐�����
            // �ʐM�ΐ�̏ꍇ
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
            // ����ȊO
            else
            {
                GameObject newObjecti = Instantiate(prefabi, positioni, Quaternion.identity);
            }
        }
    }
}
