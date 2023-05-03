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

    // テスト用にキーボードのスペースキーを押した時に新しいオブジェクトを生成する
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceObject();
        }
    }
}