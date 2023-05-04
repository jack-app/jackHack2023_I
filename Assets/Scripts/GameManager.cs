using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private TurnManager m_turnManager;

    [SerializeField]
    private PieceManager m_pieceManager;

    [SerializeField]
    private PieceStatusScriptableObject[] pieceStatusScriptableObjects = new PieceStatusScriptableObject[2];

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
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                m_pieceManager.CreateMyPieces(pieceStatusScriptableObjects[0]);
                m_turnManager.StartTurn();                
            }
            else
            {
                m_camera.transform.rotation = new Quaternion(0, 0, 1, 0);
                m_pieceManager.CreateMyPieces(pieceStatusScriptableObjects[1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
