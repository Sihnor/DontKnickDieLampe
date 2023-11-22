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

    private bool playerIsChased  = false;

    public bool PlayerIsChased  {get {return this.playerIsChased;}set {this.playerIsChased = value;}}


    private bool pickedUpTutKey = false;
    public bool PickedUpTutKey{
        get { return pickedUpTutKey;}
        set
        {
            this.pickedUpTutKey = value;
            if (pickedUpRedKey && pickedUpGreenKey && pickedUpBlueKey)
            {
                this.doorUnlocked = true;
            }
        }
    }
    
    private bool pickedUpRedKey = false;
    public bool PickedUpRedKey{
        get { return pickedUpRedKey;}
        set
        {
            this.pickedUpRedKey = value;
            if (pickedUpTutKey && pickedUpGreenKey && pickedUpBlueKey)
            {
                this.doorUnlocked = true;
            }
        }
    }
    
    private bool pickedUpGreenKey = false;
    public bool PickedUpGreenKey{
        get { return pickedUpGreenKey;}
        set
        {
            this.pickedUpGreenKey = value;
            if (pickedUpTutKey && pickedUpRedKey && pickedUpBlueKey)
            {
                this.doorUnlocked = true;
            }
        }
    }
    
    private bool pickedUpBlueKey = false;
    public bool PickedUpBlueKey{
        get { return pickedUpBlueKey;}
        set
        {
            this.pickedUpBlueKey = value;
            if (pickedUpTutKey && pickedUpRedKey && pickedUpGreenKey)
            {
                this.doorUnlocked = true;
            }
        }
    }
    
    private bool doorUnlocked = false;
    public bool DoorUnlocked {
        get { return this.doorUnlocked; }
    }

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
    
    private void OnLevelWasLoaded(int _level)
    {
        if (_level == 2)
        {
            SpawnManager.Instance.SpawnPlayer();
            SpawnManager.Instance.SpawnKeys();
        }
    }
}
