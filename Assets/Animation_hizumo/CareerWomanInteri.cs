using UnityEngine;

public class CareerWomanInteri : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

    //===== �������� =====
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }

    //===== �又�� =====
    void Update()
    {
        //�����Aa�L�[�������ꂽ��Ȃ�
        if (Input.GetKey(KeyCode.A))
        {
            //Bool�^�̃p�����[�^�[�ł���blRot��True�ɂ���
            anim.SetBool("CarrerWomanInteri", true);
        }
    }
}