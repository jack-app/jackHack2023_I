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
                        foreach (Transform child in transform)//�q�I�u�W�F�N�g���A�N�e�B�u�ɂ���
                        {
                            child.gameObject.SetActive(true);
                            clickmode = Clickmode.clickboard;

                        }
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
                        foreach (Transform child in transform)//�q�I�u�W�F�N�g���A�N�e�B�u�ɂ���
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
