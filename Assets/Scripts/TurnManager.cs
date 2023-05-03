using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun.UtilityScripts;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(PunTurnManager))]
public class TurnManager : MonoBehaviourPun, IPunTurnManagerCallbacks
{
    [SerializeField]
    private TextMeshProUGUI m_turnText;

    [SerializeField]
    private TextMeshProUGUI m_timerText;

    [SerializeField]
    private TextMeshProUGUI m_waitingText;

    private PunTurnManager m_punTurnManager;

    private int m_turnCount;

    // Start is called before the first frame update
    private void Awake()
    {
        m_punTurnManager = GetComponent<PunTurnManager>();
        m_punTurnManager.TurnManagerListener = this;
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            m_turnText.text = "Turn: " + m_punTurnManager.Turn.ToString();
            m_timerText.text = "Timer: " + m_punTurnManager.RemainingSecondsInTurn.ToString();
        }
    }

    public void OnPlayerFinished(Player player, int turn, object move)
    {
        
    }

    public void OnPlayerMove(Player player, int turn, object move)
    {
        
    }

    public void OnTurnBegins(int turn)
    {
        // ターンが開始されたときの処理
    }

    public void OnTurnCompleted(int turn)
    {
        // ターンが完了したときの処理
        StartTurn();
    }

    public void OnTurnTimeEnds(int turn)
    {
        // 時間制限に達してしまった時の処理
        StartTurn();
    }

    /// <summary>
    /// ターンを開始する
    /// </summary>
    public void StartTurn()
    {
        if (m_turnCount == m_punTurnManager.Turn)
        {
            m_turnCount++;
            if (PhotonNetwork.IsMasterClient)
            {
                m_punTurnManager.BeginTurn();
                photonView.RPC(nameof(RPC_AutomaticSend), RpcTarget.AllViaServer);
            }
        }
    }

    /// <summary>
    /// ターンを次に渡す
    /// </summary>
    public void SendTurn()
    {
        m_punTurnManager.SendMove(null, true);
    }

    /// <summary>
    /// 自分のターンかどうかを判定する
    /// </summary>
    /// <returns></returns>
    public bool IsMyTurn()
    {
        if ((m_punTurnManager.Turn % 2) + 1 == PhotonNetwork.LocalPlayer.ActorNumber) return true;
        return false;
    }

    [PunRPC]
    public void RPC_AutomaticSend()
    {
        if (IsMyTurn())
        {
            m_waitingText.text = "";
        }
        else
        {
            m_punTurnManager.SendMove(null, true);
            m_waitingText.text = "wait for another player ...";
        }
    }
}
