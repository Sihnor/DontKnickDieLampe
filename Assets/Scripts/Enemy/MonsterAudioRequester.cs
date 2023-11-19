using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class MonsterAudioRequester : MonoBehaviour
{
    [SerializeField]
    private SoundRequestCollection requests;
    [SerializeField]
    private AudioData monsterSounds;

    void Update()
    {
        if (Time.frameCount % 200 == 0)
        {
            requests.Add(SoundRequest.Request(monsterSounds));

        }
    }
}
