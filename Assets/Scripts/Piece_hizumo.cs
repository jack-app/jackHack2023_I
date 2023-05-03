using UnityEditor.Rendering;
using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{
   
    private void Update()
    {
        if (gameObject.tag == "Move")
        {
            Debug.Log("Move");
        }

    }
}