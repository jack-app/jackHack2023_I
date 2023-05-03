using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField]
    private PhotonViewDetector m_viewDetector;

    [SerializeField]
    private TurnManager m_turnManager;

    private Clickmode clickmode;
    private GameObject selectedpiece;

    private void Start()
    {
        clickmode = Clickmode.clickpiece;
    }

    public void Update()
    {
        // �ʐM�ΐ�p
        if (PhotonNetwork.InRoom)
        {
            // �����̃^�[���ł͂Ȃ������烊�^�[��
            if (!m_turnManager.IsMyTurn()) return;
        }
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
                        if (!m_viewDetector.IsMyObject(hitpiece.collider.GetComponent<PhotonView>())) return; // �ʐM�ΐ�ő���̃R�}�͑I������Ȃ�
                        Debug.Log(hitpiece.collider.gameObject.transform.position);//���W�̃��O���o��
                        selectedpiece = hitpiece.collider.gameObject;
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
                        Vector2 colliderposition = hitboard.collider.gameObject.transform.position;
                        selectedpiece.transform.position = new Vector3(colliderposition.x, colliderposition.y, selectedpiece.transform.position.z);
                        selectedpiece = null;
                        clickmode = Clickmode.clickpiece;
                        m_turnManager.SendTurn(); // �^�[�������̃v���C���[�ɓn��
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


