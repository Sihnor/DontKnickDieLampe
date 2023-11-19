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

    public static SoundRequest Request(bool is2D, AudioData _sound)
    {
        return new SoundRequest(is2D, Vector3.zero, _sound);
    }
}
