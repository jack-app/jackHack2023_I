using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player2Transform
{
    /// <summary>
    /// ‘Îí‘Šè—p‚ÉÀ•W•ÏŠ·‚ğ‚·‚é
    /// </summary>
    /// <param name="prevposition"></param>
    /// <returns></returns>
    public static Vector3 ConvertPosition(Vector3 prevposition)
    {
        return new Vector3(-prevposition.x, -prevposition.y, prevposition.z);
    }
}
