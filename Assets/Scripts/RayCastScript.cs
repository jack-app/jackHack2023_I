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
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            if (clickmode == Clickmode.clickpiece)
            {
                Ray raypiece = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray�𐶐�
                RaycastHit hitpiece;
                if (Physics.Raycast(raypiece, out hitpiece, 10.0f)) // Ray�𓊎�
                {
                    if (hitpiece.collider.CompareTag("Piece")) // �^�O���r
                    {
                        Debug.Log(hitpiece.collider.gameObject.transform.position);//���W�̃��O���o��

                        clickmode = Clickmode.clickboard;
                    }
                }

            }
            else if (clickmode == Clickmode.clickboard)
            {
                Ray rayboard = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray�𐶐�
                RaycastHit hitboard;
                if (Physics.Raycast(rayboard, out hitboard, 10.0f)) // Ray�𓊎�
                {
                    if (hitboard.collider.CompareTag("Board")) // �^�O���r
                    {
                        Debug.Log(hitboard.collider.gameObject.transform.position);//���W�̃��O���o��
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


