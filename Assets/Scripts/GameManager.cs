using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_defaultPiece; // TODO: これはコマの生成ができたら後で削除

    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private TurnManager m_turnManager;

    private void Awake()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.IsMessageQueueRunning = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // TODO: ここでコマの生成を行う
        Vector3 pos = new Vector3(0, -8, -1);
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
            {                
                PhotonNetwork.Instantiate("Piece", pos, Quaternion.identity);
            }
            else
            {
                pos = Player2Transform.ConvertPosition(pos);
                m_camera.transform.rotation = new Quaternion(0, 0, 1, 0);
                PhotonNetwork.Instantiate("Piece", pos, new Quaternion(0, 0, 1, 0));
            }
            m_turnManager.StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
