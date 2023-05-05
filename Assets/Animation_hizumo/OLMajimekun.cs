using UnityEngine;

public class OLMajimekun
    : MonoBehaviour
{
    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する
    public GameObject conservation;
    public GameObject heart;
    //===== 初期処理 =====
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    //===== 主処理 =====
    void Update()
    {
        //もし、aキーが押されたらなら
        if (Input.GetKey(KeyCode.A))
        {
            //Bool型のパラメーターであるOLMajimekunをTrueにする
            anim.SetBool("OLMajimekun", true);
        }
    }
    public void StartAnimation()
    {
        anim.SetBool("OLMajimekun", true);
    }
    public void conversation1()
    {
        //conversation1 という名前のオブジェクトを取得
        GameObject con1 = GameObject.Find("conversation(Clone)");
        // 指定したオブジェクトを削除
        Destroy(con1);
    }
    public void conversation2()
    {
        //conversation2 という名前のオブジェクトを取得
        GameObject con2 = GameObject.Find("conversation(Clone)");
        // 指定したオブジェクトを削除
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
        //love という名前のオブジェクトを取得
        GameObject love = GameObject.Find("heart_shape-1(Clone)");
        // 指定したオブジェクトを削除
        Destroy(love);
    }
}