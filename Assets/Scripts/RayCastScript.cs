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
        // 通信対戦用
        if (PhotonNetwork.InRoom)
        {
            // 自分のターンではなかったらリターン
            if (!m_turnManager.IsMyTurn()) return;
        }
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
                        // 通信対戦で相手のコマは選択されない
                        if (PhotonNetwork.InRoom)
                        {
                            if (!m_viewDetector.IsMyObject(hitpiece.collider.GetComponent<PhotonView>())) return;
                        }
                        Debug.Log(hitpiece.collider.gameObject.transform.position);//座標のログを出す
                        selectedpiece = hitpiece.collider.gameObject;
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
                        Vector2 colliderposition = hitboard.collider.gameObject.transform.position;
                        selectedpiece.transform.position = new Vector3(colliderposition.x, colliderposition.y, selectedpiece.transform.position.z);
                        selectedpiece = null;
                        clickmode = Clickmode.clickpiece;
                        if (PhotonNetwork.InRoom)
                        {
                            m_turnManager.SendTurn(); // ターンを次のプレイヤーに渡す
                        }
                    }
                    else
                    {
                        selectedpiece = null;
                        clickmode = Clickmode.clickpiece;
                    }
                }
                else
                {
                    selectedpiece = null;
                    clickmode = Clickmode.clickpiece;
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


