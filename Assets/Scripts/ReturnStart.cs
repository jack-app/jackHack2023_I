using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ReturnStart : MonoBehaviour
{
    [SerializeField]
    private string m_sceneName;

    public void Return()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(m_sceneName);
    }
}
