using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Piece_hizumo : MonoBehaviour
{
    public GameObject prefab; // ��������I�u�W�F�N�g��Prefab��Inspector�Ŏw�肷��

    private GameObject PlaceObject()
    {
        // ���̃I�u�W�F�N�g�̈ʒu�Ɖ�]���擾����
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // �V�����I�u�W�F�N�g�𐶐�����
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
        Vector3 posi = this.transform.position;//���g�̍��W���擾
        for (int i = 0; i < tmp.Length; i++)
        {
            float threshold = 0.1f; // ���W�̍������̒l�ȉ��Ȃ��v�����Ƃ݂Ȃ�
            if (Vector2.Distance(tmp[i].transform.position, posi) < threshold)
            {
                GameObject newObject = PlaceObject();// �R�}�𐬂点��
                return (true, newObject);
            }
        }
        return (false, null);
    }

}
    
    
       
