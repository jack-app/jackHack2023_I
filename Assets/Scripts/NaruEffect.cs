using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaruEffect : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public ParticleSystem _particleSystem1;
    public ParticleSystem _particleSystem2;
    public GameObject Particle;
    public Camera _camera;
    public AudioSource _audioSource;
    
    // �e�X�g�p�ɃL�[�{�[�h�̃X�y�[�X�L�[�����������ɐV�����I�u�W�F�N�g�𐶐�����
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
            PlayEffect(mousePosition);
        }
    }

    public void PlayEffect(Vector3 position)
    {
        Particle.transform.position = position;
        _particleSystem.Play();
        _particleSystem1.Play();
        _particleSystem2.Play();
        _audioSource.Play();
    }
}