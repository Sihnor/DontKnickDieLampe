using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(AudioSource))]
public class AudioPoolObject : MonoBehaviour
{
    public AudioSource Source => m_AudioSource;

    private AudioSource m_AudioSource;
    public IObjectPool<GameObject> pool;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (m_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            transform.SetParent(null);
            if (pool != null)
            {
                ReturnToPool();
            }
        }
    }

    private void ReturnToPool()
    {
        pool.Release(gameObject);
    }
}
