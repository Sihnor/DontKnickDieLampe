using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool paused;
    public float xSensitivity;
    public float ySensitivity;

    public bool lightingOn = false;

    public bool pickedUpTutKey = false;
    public bool pickedUpRedKey = false;
    public bool pickedUpGreenKey = false;
    public bool pickedUpBlueKey = false;

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
}
