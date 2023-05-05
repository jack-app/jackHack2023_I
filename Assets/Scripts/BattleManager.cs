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
        if(a.characterType == CharacterType.Otaku && b.characterType == CharacterType.Gal || a.characterType == CharacterType.Gal && b.characterType == CharacterType.Otaku)
        {
            return 2;
        }
        else if (a.characterType == CharacterType.CareerWoman && b.characterType == CharacterType.Intelli || a.characterType == CharacterType.Intelli && b.characterType == CharacterType.CareerWoman)
        {
            return 3;
        }
        else if (a.characterType == CharacterType.Majime && b.characterType == CharacterType.OL || a.characterType == CharacterType.OL && b.characterType == CharacterType.Majime)
        {
            return 4;
        }
        else if (a.characterType == CharacterType.BandMan && b.characterType == CharacterType.OtonaOnesan || a.characterType == CharacterType.OtonaOnesan && b.characterType == CharacterType.BandMan)
        {
            return 5;
        }
        else if (a.characterType == CharacterType.Charao && b.characterType == CharacterType.Onesan)
        {
            return 6;
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
