using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

        }
    }

    public void ActivateBoard()
    {
        foreach (Transform child in transform)//�q�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        {
            child.gameObject.SetActive(true);
        }
    }

    public void InActivateBoard()
    {
        foreach (Transform child in transform)//�q�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        {
            child.gameObject.SetActive(false);
        }
    }
}
