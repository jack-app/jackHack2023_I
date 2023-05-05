using UnityEngine;

public class OtonaonesanBandoman

    : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����
    public GameObject money;
    public GameObject heart;
    public GameObject sweat;
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
            //Bool�^�̃p�����[�^�[�ł���OtonaonesanBandoman��True�ɂ���
            anim.SetBool("OtonaonesanBandoman", true);
        }
    }
    public void StartAnimation()
    {
        anim.SetBool("OtonaonesanBandoman", true);
    }
    public void love()
    {
        Instantiate(heart, new Vector3(4.54f, 1.95f, -3), Quaternion.identity);
    }
    public void loveout()
    {
        //love �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject love = GameObject.Find("heart_shape-1(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(love);
    }
    public void moneymake1()
    {
        Instantiate(money, new Vector3(-3.114566f, 2.498216f, -3), Quaternion.identity);
    }
    public void moneymake2()
    {
        Instantiate(money, new Vector3(-0.01f, 1.45f, -3), Quaternion.identity);

    }
    public void moneymake3()
    {

        Instantiate(money, new Vector3(-0.01f, -0.15f, -3), Quaternion.identity);

    }
    public void moneymake4()
    {

        Instantiate(money, new Vector3(-0.01f, -2.00f, -3), Quaternion.identity);

    }
    public void moneyout()
    {
        GameObject[] money = GameObject.FindGameObjectsWithTag("money");

        if (money != null)
        {
            foreach (GameObject obj in money)
            {
                if (obj.activeSelf)
                {
                    Destroy(obj);
                }
            }
        }
    }

    public void run1()
    {
        Instantiate(sweat, new Vector3(-2.4444f, 0.66f, -5), Quaternion.identity);
    }
    public void run2()
    {
        Instantiate(sweat, new Vector3(-5.0f, 0.66f, -5), Quaternion.identity);
    }
    public void runout()
    {
        //sweat �Ƃ������O�̃I�u�W�F�N�g���擾
        GameObject sweat = GameObject.Find("Sweat(Clone)");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(sweat);
    }
}
