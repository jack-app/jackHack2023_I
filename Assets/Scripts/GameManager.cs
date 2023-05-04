using UnityEngine;
using UnityEditor;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private TurnManager m_turnManager;

    [SerializeField]
    private PieceManager m_pieceManager;

    [SerializeField]
    private BattleManager m_battleManager;

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

    public void ButtleMove(CharacterStatus status)
    {        
        CharacterStatus enemystatus = m_battleManager.SearchEnemy(status);
        if (enemystatus == null) 
        {
            m_turnManager.SendTurn(); // ターンを次のプレイヤーに渡す
            return;
        }
        Debug.Log(enemystatus.gameObject.name);
        Vector2Int piecePos = FieldManager.Instance.ConvertRealPosToArrayPos(enemystatus.gameObject.transform.position);
        int battleresult = m_battleManager.Battle(status, enemystatus);
        Debug.Log(battleresult);
        switch (battleresult)
        {
            case 0:
                enemystatus.GetComponent<ManageMyObj>().DestroyMyObj();
                FieldManager.Instance.SetPieceToField(PhotonNetwork.LocalPlayer.ActorNumber, piecePos.x, piecePos.y);
                m_turnManager.SendTurn(); // ターンを次のプレイヤーに渡す
                break;
            case 1:
                status.GetComponent<ManageMyObj>().DestroyMyObj();
                FieldManager.Instance.SetPieceToField(PhotonNetwork.LocalPlayer.GetNextFor(PhotonNetwork.LocalPlayer.ActorNumber).ActorNumber, piecePos.x, piecePos.y);
                m_turnManager.SendTurn(); // ターンを次のプレイヤーに渡す
                break;
            default:
                break;
        }
    }
}
