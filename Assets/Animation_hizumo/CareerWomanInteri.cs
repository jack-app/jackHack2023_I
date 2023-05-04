using UnityEngine;

public class CareerWomanInteri : MonoBehaviour
{
    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する

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
            //Bool型のパラメーターであるblRotをTrueにする
            anim.SetBool("CarrerWomanInteri", true);
        }
    }
}