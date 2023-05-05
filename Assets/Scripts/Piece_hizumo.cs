using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{
    public GameObject prefab; // 生成するオブジェクトのPrefabをInspectorで指定する

    private GameObject PlaceObject()
    {
        // 元のオブジェクトの位置と回転を取得する
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // 新しいオブジェクトを生成する
        if (PhotonNetwork.InRoom)
        {
            GameObject newObject= PhotonNetwork.Instantiate(prefab.name, position, rotation);
            gameObject.GetComponent<ManageMyObj>().DestroyMyObj(RpcTarget.All);
            NaruEffect.Instance.PlayEffect((int)position.x, (int)position.y, (int)position.z);
            return newObject;
        }
        else
        {
            GameObject newObject = Instantiate(prefab, position, rotation);
            Destroy(gameObject);
            return newObject;
        }
    }

    public (bool, GameObject) Promotion()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Change");
        Vector3 posi = this.transform.position;//自身の座標を取得
        for (int i = 0; i < tmp.Length; i++)
        {
            float threshold = 0.1f; // 座標の差がこの値以下なら一致したとみなす
            if (Vector2.Distance(tmp[i].transform.position, posi) < threshold)
            {
                GameObject newObject = PlaceObject();// コマを成らせる
                return (true, newObject);
            }
        }
        return (false, null);
    }

}
    
    
       
