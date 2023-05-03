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

    // �e�X�g�p�ɃL�[�{�[�h�̃X�y�[�X�L�[�����������ɐV�����I�u�W�F�N�g�𐶐�����
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceObject();
        }
    }
}