using UnityEngine;

public class CareerWomanInteri : MonoBehaviour
{
    //===== 定義領域 =====
    public Animator anim;  //Animatorをanimという変数で定義する
    public GameObject conservation;
    public GameObject building;
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
            //Bool型のパラメーターであるCarrerWomanInteriをTrueにする
            anim.SetBool("CarrerWomanInteri", true);
        }
    }
    public void StartAnimation()
    {
        anim.SetBool("CarrerWomanInteri", true);
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
        //cbuilding という名前のオブジェクトを取得
        GameObject building = GameObject.Find("building(Clone)");
        // 指定したオブジェクトを削除
        Destroy(building);
    }
}