using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{

    public GameObject prefab; // 生成するオブジェクトのPrefabをInspectorで指定する

    private void PlaceObject()
    {
        // 元のオブジェクトの位置と回転を取得する
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // 新しいオブジェクトを生成する
        GameObject newObject = Instantiate(prefab, position, rotation);

        Destroy(gameObject);
    }

    
    private void Update()
    {
        
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("ChangeBoard");
        Vector3 posi = this.transform.position;//自身の座標を取得
        for (int i = 0; i < tmp.Length; i++)
        {
            float threshold = 0.1f; // 座標の差がこの値以下なら一致したとみなす
            if (Vector2.Distance(tmp[i].transform.position, posi) < threshold)
            {
                PlaceObject();// コマを成らせる

                //ChangeBoard という名前のオブジェクトを取得
                GameObject obj = GameObject.Find("ChangeBoard");
                // 指定したオブジェクトを削除
                //Destroy(obj);
            }
        }
    }

}
    
    
       
