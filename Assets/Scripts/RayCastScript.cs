using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField]
    private GameManager m_gameManager;

    [SerializeField]
    private TurnManager m_turnManager;

    [SerializeField]
    private PhotonViewDetector m_viewDetector;

    [SerializeField]
    private ChangeBoard m_changeBoard;

    [SerializeField]
    private PhotonPlaySE m_photonPlaySE;

    private Clickmode clickmode;
    private GameObject selectedpiece;
    private AbleSelect ableSelect;

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
                        // �ʐM�ΐ�ő���̃R�}�͑I������Ȃ�
                        if (PhotonNetwork.InRoom)
                        {
                            if (!m_viewDetector.IsMyObject(hitpiece.collider.GetComponent<PhotonView>())) return;
                        }
                        selectedpiece = hitpiece.collider.gameObject;
                        ableSelect = selectedpiece.GetComponentInChildren<AbleSelect>();
                        ableSelect.ActivateBoard();
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
                        Vector3 colliderposition = hitboard.collider.gameObject.transform.position;
                        Vector3 prevposition  = selectedpiece.transform.position;
                        selectedpiece.transform.position = new Vector3(colliderposition.x, colliderposition.y, prevposition.z);
                        if (PhotonNetwork.InRoom)
                        {
                            // �R�}���w������炷
                            m_photonPlaySE.PlaySE();
                            //�R�}���ړ���z��ɓ���������
                            Vector2Int prevpos  = FieldManager.Instance.ConvertRealPosToArrayPos(prevposition);
                            Vector2Int afterpos = FieldManager.Instance.ConvertRealPosToArrayPos(selectedpiece.transform.position);
                            FieldManager.Instance.RemovePieceToField(prevpos.x, prevpos.y);
                            // ������̃R�}�������ʒu�ɗ�����
                            if (FieldManager.Instance.CheckBattle(afterpos.x, afterpos.y))
                            {
                                m_gameManager.ButtleMove(selectedpiece.GetComponent<CharacterStatus>());
                            }
                            else
                            {
                                FieldManager.Instance.SetPieceToField(PhotonNetwork.LocalPlayer.ActorNumber, afterpos.x, afterpos.y);
                                m_turnManager.SendTurn(); // �^�[�������̃v���C���[�ɓn��
                            }
                        }
                    }
                }
                m_changeBoard.Change();
                ableSelect.InActivateBoard();
                ableSelect = null;
                selectedpiece = null;
                clickmode = Clickmode.clickpiece;
            }
        }

    }
    public enum Clickmode
    {
        clickpiece,
        clickboard,
    }
}


