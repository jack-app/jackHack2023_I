using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cardNameText;
    [SerializeField]
    private int resultnumber;
    // Start is called before the first frame update
    void Start()
    {
        Effect(resultnumber );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Effect(int battleresult)
    {
        if (battleresult == 0)
　　　　{
            cardNameText.text = "勝ち";
            cardNameText.color = Color.blue;

                ;
        }
        else if (battleresult == 1)
        {
            cardNameText.text = "負け";
            cardNameText.color = Color.blue;
        }
        else
        {
            cardNameText.text = "特殊";
            cardNameText.color = Color.blue;
        }
    }
}
