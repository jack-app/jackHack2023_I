using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        // ���W���擾
        Vector3 pos = myTransform.position;

        
        if (Mathf.Abs(pos.x) > 10 | Mathf.Abs(pos.y)> 10)//�����Ֆʂ̊O��������
        {
            GetComponent<Renderer>().material.color = Color.red;//�{�[�h��ԐF�ɂ���
            this.tag = "NotBoard";//�^�O���{�[�h�ł͂Ȃ���
        }
        else//�����Ֆʂ̒���������
        {
            GetComponent<Renderer>().material.color = Color.green;//�{�[�h��ΐF�ɂ���
            this.tag = "Board";//�^�O���{�[�h�ɂ���
        }
    }
}