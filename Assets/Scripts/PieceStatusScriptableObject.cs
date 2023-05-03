using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create PieceData")]//メニューからAssetを作れるように属性の追加
public class PieceStatusScriptableObject : ScriptableObject //ScriptableObjectの使用
{
    public List<PieceParam> list = new List<PieceParam>();

    [System.Serializable]
    public class PieceParam //Listに入るパラメーター
    {
        public string name;
        public int num;
        public GameObject prefab;
        public Vector3 Position;
    }
}