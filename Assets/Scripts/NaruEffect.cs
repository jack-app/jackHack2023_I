using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NaruEffect : MonoBehaviourPun
{
    public static NaruEffect Instance { get; private set; }

    public ParticleSystem _particleSystem;
    public ParticleSystem _particleSystem1;
    public ParticleSystem _particleSystem2;
    public GameObject Particle;
    public AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayEffect(int x, int y, int z)
    {
        photonView.RPC(nameof(RPC_PlayEffect), RpcTarget.AllViaServer, x, y, z);
    }

    [PunRPC]
    public void RPC_PlayEffect(int x, int y, int z)
    {
        Particle.transform.localPosition = new Vector3(x, y, 0);
        _particleSystem.Play();
        _particleSystem1.Play();
        _particleSystem2.Play();
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}