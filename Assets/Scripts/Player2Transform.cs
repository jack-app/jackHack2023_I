using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player2Transform
{
    /// <summary>
    /// 対戦相手用に座標変換をする
    /// </summary>
    /// <param name="prevposition"></param>
    /// <returns></returns>
    public static Vector3 ConvertPosition(Vector3 prevposition)
    {
        return new Vector3(-prevposition.x, -prevposition.y, prevposition.z);
    }
}
