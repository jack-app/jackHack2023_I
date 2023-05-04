using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public CharacterStatus SearchEnemy(CharacterStatus status)
    {
        Vector2 pos = status.gameObject.transform.position;
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");
        foreach (GameObject piece in pieces)
        {
            CharacterStatus enemystatus = piece.GetComponent<CharacterStatus>();
            if (Vector2.Distance(pos, piece.transform.position) < 0.1f &&  status.characterType != enemystatus.characterType)
            {
                return enemystatus;
            }
        }
        return null;
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
