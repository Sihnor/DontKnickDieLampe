using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "newAudioData", menuName = "Data/Audio Data/Clip Data")]
public class AudioData : ScriptableObject
{
    public float Volume => volume; 
    public AudioClip[] Clips => clips;

    [SerializeField] private float volume = 1.0f;
    [SerializeField] private AudioClip[] clips;
}
