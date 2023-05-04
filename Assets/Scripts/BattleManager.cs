using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Battle(CharacterStatus a, CharacterStatus b)
    {
        //í“¬Žž‚Ìˆ—
        if(a.characterType == CharacterType.Otaku && b.characterType == CharacterType.Gal)
        {
            return 2;
        }
        else if((a.looks + a.money + a.intelligence + a.communication)* 1.5 >= (b.looks + b.money + b.intelligence + b.communication))
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
