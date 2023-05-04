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
    private ResultManager m_resultManager;

    [SerializeField]
    private DirectionManager m_directionManager;

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
                break;
            case 1:
                status.GetComponent<ManageMyObj>().DestroyMyObj();
                FieldManager.Instance.SetPieceToField(PhotonNetwork.LocalPlayer.GetNextFor(PhotonNetwork.LocalPlayer.ActorNumber).ActorNumber, piecePos.x, piecePos.y);
                break;
            case 3:
                // インテリとキャリアウーマンの駆け落ち
                status.GetComponent<ManageMyObj>().DestroyMyObj();
                enemystatus.GetComponent<ManageMyObj>().DestroyMyObj();
                FieldManager.Instance.SetPieceToField(0, piecePos.x, piecePos.y);
                m_directionManager.WomanInteri();
                break;
            default:
                break;
        }
        m_turnManager.SendTurn(); // ターンを次のプレイヤーに渡す
        photonView.RPC(nameof(RPC_JudgeGameEnd), RpcTarget.AllViaServer);
    }

    [PunRPC]
    public void RPC_JudgeGameEnd()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        int p1PieceCount = 0;
        int p2PieceCount = 0;
        for (int y = 0; y < FieldData.FIELD_LENGTH; y++)
        {
            for (int x = 0; x < FieldData.FIELD_LENGTH; x++)
            {
                int piecenum = FieldManager.Instance.GetPieceToField(x, y);
                if (piecenum == 1) { p1PieceCount++; }
                if(piecenum == 2) { p2PieceCount++; }
            }
        }
        Debug.Log("1P" + p1PieceCount + ", 2P" + p2PieceCount);
        // 引き分け0, 他、勝ったほうの番号渡す
        if (p1PieceCount == 0 && p2PieceCount == 0)
        {
            m_resultManager.ShowResult(0);
        }
        else if (p1PieceCount == 0)
        {
            m_resultManager.ShowResult(2);
        }
        else if (p2PieceCount == 0)
        {
            m_resultManager.ShowResult(1);
        }
    }
}
