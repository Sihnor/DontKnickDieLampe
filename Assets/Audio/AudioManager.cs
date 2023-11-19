using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private string managerTag = "Manager";

    private IObjectPool<GameObject> pool;

    [SerializeField] private int maxPoolSize;
    [SerializeField] private GameObject poolPrefab;
    [SerializeField] private SoundRequestCollection requests;


    private void Awake()
    {
        gameObject.tag = managerTag;
        GameObject[] tmp = GameObject.FindGameObjectsWithTag(managerTag);
        if (tmp.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnToPool, OnDestroyPoolObject, true, maxPoolSize, maxPoolSize);
    }

    private void Start()
    {
        requests.OnAdd += OnSoundRequest;
    }

    private void OnSoundRequest(SoundRequest _request)
    {
        AudioPoolObject temp = pool.Get().GetComponent<AudioPoolObject>();
        AudioSource tempSource = temp.Source;
        AudioData tempData = _request.Sound;

        temp.transform.position = _request.Position;
        temp.name = $"{tempData.name}";
        //tempSource.outputAudioMixerGroup
        tempSource.clip = tempData.Clips[Random.Range(0,tempData.Clips.Length)];
        tempSource.volume = tempData.Volume;
        tempSource.spatialBlend = _request.Is2D ? 0 : 1;
        tempSource.Play();
        requests.Remove(_request);
    }

    public GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(poolPrefab);
        AudioPoolObject temp = obj.GetComponent<AudioPoolObject>();
        temp.pool = pool;
        obj.SetActive(true);
        return obj;
    }

    public void OnTakeFromPool(GameObject _object)
    {
        _object.SetActive(true);
    }

    public void OnReturnToPool(GameObject _object)
    {
        _object.SetActive(false);
    }

    public void OnDestroyPoolObject(GameObject _object)
    {
        Destroy(_object);
    }
}
