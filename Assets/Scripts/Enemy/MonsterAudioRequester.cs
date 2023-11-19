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

    private void Update()
    {
        if (Time.frameCount % 1200 == 0)
        {
            requests.Add(SoundRequest.Request(false, monsterSounds));
        }
    }

}
