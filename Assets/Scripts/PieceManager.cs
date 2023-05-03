using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PieceManager : MonoBehaviour
{
    GameObject prefabi;
    Vector3 Positioni;

    // ScriptableObject�𒼐ڃA�^�b�`�������ꍇ�͈ȉ��̃R�����g�A�E�g���O���Ă��������B
    //public EnemyStatusScriptableObject enemyStatusScriptableObject;

    // ScriptableObject�̃p�X���w��iScriptableObject���E�N���b�N>copy path�擾�ł��܂��B�j
    string filePath = "Assets/New Piece Status Scriptable Object.asset";

    private void Start()
    {
        // ScriptableObject�̃p�X���w�肵�āAEnemyStatusScriptableObject���擾����B
        // ��̃R�����g�A�E�g���O�����ꍇ�́A��������R�����g�A�E�g���Ă�������
        PieceStatusScriptableObject pieceStatusScriptableObject = AssetDatabase.LoadAssetAtPath<PieceStatusScriptableObject>(filePath);

        int listCount = pieceStatusScriptableObject.list.Count;//List�̗v�f���̎擾 
        Debug.Log("listCount:"+listCount);
        for (int i = 0; i < listCount; i++)
        {
            prefabi = pieceStatusScriptableObject.list[i].prefab;//prefab�̎擾
            Positioni = pieceStatusScriptableObject.list[i].Position;//Position�̎擾


            Debug.Log("prefab:" + prefabi);
            Debug.Log("Positon:" + Positioni);


            // �V�����I�u�W�F�N�g�𐶐�����
            GameObject newObjecti = Instantiate(prefabi, Positioni, Quaternion.identity);

        }
    }
}
