using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleSelect : MonoBehaviour
{
    private Clickmode clickmode;
    // Start is called before the first frame update
    void Start()
    {
        clickmode = Clickmode.clickpiece;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            if (clickmode == Clickmode.clickpiece)
            {
                Ray raypiece = Camera.main.ScreenPointToRay(Input.mousePosition); // Rayを生成
                RaycastHit hitpiece;
                if (Physics.Raycast(raypiece, out hitpiece, 10.0f)) // Rayを投射
                {
                    if (hitpiece.collider.CompareTag("Piece")) // タグを比較
                    {
                        foreach (Transform child in transform)//子オブジェクトをアクティブにする
                        {
                            child.gameObject.SetActive(true);
                            clickmode = Clickmode.clickboard;

                        }
                    }
                }
            }
            else if (clickmode == Clickmode.clickboard)
            {
                Ray rayboard = Camera.main.ScreenPointToRay(Input.mousePosition); // Rayを生成
                RaycastHit hitboard;
                if (Physics.Raycast(rayboard, out hitboard, 10.0f)) // Rayを投射
                {
                    if (hitboard.collider.CompareTag("Board")) // タグを比較
                    {
                        foreach (Transform child in transform)//子オブジェクトを非アクティブにする
                        {
                            child.gameObject.SetActive(false);
                            clickmode = Clickmode.clickpiece;
                        }
                    }
                }
            }
            
        }
    }
    public enum Clickmode
    {
        clickpiece,
        clickboard,
    }
}
