using UnityEngine;

public class OLMajimekun
    : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
    public GameObject conservation;
    public GameObject heart;
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
            //Bool�^�̃p�����[�^�[�ł���OLMajimekun��True�ɂ���
            anim.SetBool("OLMajimekun", true);
        }
    }
    public void StartAnimation()
    {
        anim.SetBool("OLMajimekun", true);
    }
    public void conversation1()
    {
        //conversation1 �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject con1 = GameObject.Find("conversation(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(con1);
    }
    public void conversation2()
    {
        //conversation2 �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject con2 = GameObject.Find("conversation(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(con2);
    }
    public void conservationStart1()
    {
        Instantiate(conservation, new Vector3(-0.03f, 2.51f,-3f), Quaternion.identity);
    }
    public void conservationStart2()
    {
        Instantiate(conservation, new Vector3(4.28f, 2.45f, -3f), Quaternion.identity);
    }
    public void love()
    {
        Instantiate(heart, new Vector3(0.0f, 1.99f, -3f), Quaternion.identity);
    }
    
    public void loveout()
    {
        //love �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject love = GameObject.Find("heart_shape-1(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(love);
    }
}