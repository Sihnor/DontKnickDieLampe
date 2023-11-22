using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisappear : MonoBehaviour
{
    [SerializeField] private GameObject BlueLock;
    [SerializeField] private GameObject RedLock;
    [SerializeField] private GameObject GreenLock;

    private void FixedUpdate()
    {
        if (GameManager.Instance.PickedUpRedKey)
        {
            this.RedLock.SetActive(false);
        }
        
        if (GameManager.Instance.PickedUpBlueKey)
        {
            this.BlueLock.SetActive(false);
        }
        
        if (GameManager.Instance.PickedUpGreenKey)
        {
            this.GreenLock.SetActive(false);
        }
    }
}
