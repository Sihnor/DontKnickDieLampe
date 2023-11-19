using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{

    [SerializeField] private Transform DoorTransform;
    [SerializeField] private OnLeftSide LeftSideScript;
    [SerializeField] private OnRightSide RightSideScript;

    public bool PlayerIsStaying = false;

    [SerializeField] public float RotationSpeed = 1;

    public int CurrentDoorTick = 0;
    [SerializeField] private int CloseDoorTick = 100;
    

    public bool IsLeftRotation = false;
    public bool IsRightRotation = false;
    public bool IsRotationFinished = true;
    public bool DoorHasToClose = false;
    public bool IsDoorClosed = true;

    public float RotationOffset = 0;

    private void Start()
    {
        this.RotationOffset = transform.rotation.eulerAngles.y;
    }

    public void OnLeftSideTrigger()
    {
        if (!this.IsDoorClosed)
        {
            return;
        }
        this.RightSideScript.SetOnOtherSideTrigger(true);
        this.IsLeftRotation = true;
    }

    public void OnRightSideTrigger()
    {
        if (!this.IsDoorClosed)
        {
            return;
        }
        this.LeftSideScript.SetOnOtherSideTrigger(true);
        this.IsRightRotation = true;
    }

    private void Update()
    {
        if (this.IsLeftRotation || this.IsRightRotation)
        {
            this.RotateToOpenDoor();
        }

        if (this.DoorHasToClose)
        {
            RotateToCloseDoor();
        }
    }

    private void FixedUpdate()
    {
        if (!this.IsRotationFinished)
        {
            return;   
        }

        if (this.PlayerIsStaying)
        {
            return;
        }

        if (this.IsDoorClosed)
        {
            return;
        }

        this.CurrentDoorTick++;

        if (this.CurrentDoorTick < this.CloseDoorTick)
        {
            return;
        }

        this.CurrentDoorTick = 0;
        this.DoorHasToClose = true;
    }

    void RotateToOpenDoor()
    {
        this.IsRotationFinished = false;
        this.IsDoorClosed = false;
        
        Quaternion targetRotation = new Quaternion();
        
        if (this.IsRightRotation)
        {
            targetRotation = Quaternion.Euler(0,RotationOffset + -90,0);
        }

        if (this.IsLeftRotation)
        {
            targetRotation = Quaternion.Euler(0,RotationOffset + 90,0);
        }

        this.DoorTransform.rotation = Quaternion.RotateTowards(DoorTransform.rotation, targetRotation,
            Time.deltaTime * this.RotationSpeed);

        if (DoorTransform.rotation != targetRotation) return;
        
        this.IsRightRotation = false;
        this.IsLeftRotation = false;
        this.IsRotationFinished = true;
    }

    void RotateToCloseDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, RotationOffset,0);

        this.DoorTransform.rotation = Quaternion.RotateTowards(DoorTransform.rotation, targetRotation,
            Time.deltaTime * this.RotationSpeed);

        if (DoorTransform.rotation != targetRotation) return;

        this.DoorHasToClose = false;
        this.IsDoorClosed = true;
        this.LeftSideScript.SetOnOtherSideTrigger(false);
        this.RightSideScript.SetOnOtherSideTrigger(false);
    }
}
