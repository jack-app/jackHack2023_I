using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{
    public bool isCalledOnce;
    public void Update()
    {
        Debug.Log(isCalledOnce);
        if (gameObject.tag == "Move")
        {
            Debug.Log(gameObject.tag);
            
            if (isCalledOnce == true)
            {
                transform.position = new Vector3(3.0f, 3.0f, 0.0f);
                gameObject.tag = "Piece";
                isCalledOnce = false;
               
            }
        }

    }
}