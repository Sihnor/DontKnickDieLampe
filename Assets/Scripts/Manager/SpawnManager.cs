using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    [SerializeField] public GameObject player;
    [SerializeField] public List<GameObject> playerSpawnPoints;
    [SerializeField] public List<GameObject> keys;
    [SerializeField] public List<GameObject> keySpawnPoints;
    public System.Random rnd = new System.Random();

    public void SpawnPlayer()
    {
        int tempIndex = rnd.Next(0,playerSpawnPoints.Count);
        player.transform.position = playerSpawnPoints[tempIndex].transform.position;
        player.transform.rotation = playerSpawnPoints[tempIndex].transform.rotation;
    }
    public void SpawnKeys()
    {
        foreach(GameObject curKey in keys)
        {
            int tempIndex = rnd.Next(0, keySpawnPoints.Count);
            curKey.transform.position = keySpawnPoints[tempIndex].transform.position;
            curKey.transform.rotation = keySpawnPoints[tempIndex].transform.rotation;
            keySpawnPoints.RemoveAt(tempIndex);
        }
    }
}
