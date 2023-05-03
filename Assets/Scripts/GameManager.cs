using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.IsMessageQueueRunning = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
