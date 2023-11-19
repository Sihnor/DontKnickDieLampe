using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRequest
{
    public AudioData Sound { get; }

    public bool Is2D { get; }
    public Vector3 Position { get; }

    private SoundRequest(bool _is2D, Vector3 _position, AudioData _sound)
    {
        Sound = _sound;
        Is2D = _is2D;
        Position = _position;
    }

    public static SoundRequest Request(AudioData _sound)
    {
        return new SoundRequest(true, Vector3.zero, _sound);
    }
}
