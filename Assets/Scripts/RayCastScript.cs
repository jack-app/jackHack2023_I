using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    Clickmode clickmode;

    private void Update()
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
                        Debug.Log(hitpiece.collider.gameObject.transform.position);//座標のログを出す

                        clickmode = Clickmode.clickboard;
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
                        Debug.Log(hitboard.collider.gameObject.transform.position);//座標のログを出す
                        float x = hitboard.collider.gameObject.transform.position.x;
                        float y = hitboard.collider.gameObject.transform.position.y;
                        float z = hitboard.collider.gameObject.transform.position.z;
                        clickmode = Clickmode.clickpiece;
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

    private void Start()
    {

        clickmode = Clickmode.clickpiece;
    }
}


