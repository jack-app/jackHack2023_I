using UnityEngine;

public class CareerWomanInteri : MonoBehaviour
{
    //===== ��`�̈� =====
    public Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
    public GameObject conservation;
    public GameObject building;
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
            //Bool�^�̃p�����[�^�[�ł���CarrerWomanInteri��True�ɂ���
            anim.SetBool("CarrerWomanInteri", true);
        }
    }
    public void StartAnimation()
    {
        anim.SetBool("CarrerWomanInteri", true);
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
        Instantiate(conservation, new Vector3(-0.03f, 2.51f, 0.0f), Quaternion.identity);
    }
    public void conservationStart2()
    {
        Instantiate(conservation, new Vector3(4.28f, 2.45f, 0.0f), Quaternion.identity);
    }
    public void build()
    {
        Instantiate(building, new Vector3(0.0f, 2.77f, 0.0f), Quaternion.identity);
    }
    
    public void buildout()
    {
        //cbuilding �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject building = GameObject.Find("building(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(building);
    }
}