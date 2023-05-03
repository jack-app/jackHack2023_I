using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create PieceData")]//���j���[����Asset������悤�ɑ����̒ǉ�
public class PieceStatusScriptableObject : ScriptableObject //ScriptableObject�̎g�p
{
    public List<PieceParam> list = new List<PieceParam>();

    [System.Serializable]
    public class PieceParam //List�ɓ���p�����[�^�[
    {
        public string name;
        public int num;
        public GameObject prefab;
        public Vector3 Position;
    }
}