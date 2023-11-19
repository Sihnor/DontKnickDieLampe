using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRightSide : MonoBehaviour
{
    [SerializeField] DoorLogic DoorLogicScript;

    public bool OtherTriggerActive = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (this.OtherTriggerActive)
        {
            return;
        }
        
        DoorLogicScript.OnRightSideTrigger();
    }

    private void OnTriggerStay(Collider other)
    {
        if (this.DoorLogicScript.IsRotationFinished)
        {
            this.OtherTriggerActive = true;
            this.DoorLogicScript.PlayerIsStaying = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        this.DoorLogicScript.PlayerIsStaying = false;
    }

    private void OnTriggerExit(Collider other)
    {
        this.DoorLogicScript.PlayerIsStaying = false;
    }

    public void SetOnOtherSideTrigger(bool _otherTrigger)
    {
        this.OtherTriggerActive = _otherTrigger;
    }
}
