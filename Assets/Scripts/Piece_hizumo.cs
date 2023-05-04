using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{

    public GameObject prefab; // ��������I�u�W�F�N�g��Prefab��Inspector�Ŏw�肷��

    private void PlaceObject()
    {
        // ���̃I�u�W�F�N�g�̈ʒu�Ɖ�]���擾����
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // �V�����I�u�W�F�N�g�𐶐�����
        GameObject newObject = Instantiate(prefab, position, rotation);

        Destroy(gameObject);
    }

    
    private void Update()
    {
        
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("ChangeBoard");
        Vector3 posi = this.transform.position;//���g�̍��W���擾
        for (int i = 0; i < tmp.Length; i++)
        {
            float threshold = 0.1f; // ���W�̍������̒l�ȉ��Ȃ��v�����Ƃ݂Ȃ�
            if (Vector2.Distance(tmp[i].transform.position, posi) < threshold)
            {
                PlaceObject();// �R�}�𐬂点��

                //ChangeBoard �Ƃ������O�̃I�u�W�F�N�g���擾
                GameObject obj = GameObject.Find("ChangeBoard");
                // �w�肵���I�u�W�F�N�g���폜
                //Destroy(obj);
            }
        }
    }

}
    
    
       
