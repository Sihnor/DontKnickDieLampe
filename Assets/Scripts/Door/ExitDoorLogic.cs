using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorLogic : MonoBehaviour
{
    [SerializeField] private Transform PointOne;
    [SerializeField] private Transform PointTwo;

    [SerializeField] private Transform DoorTransform;
    [SerializeField] private Transform PlayerTransform;

    public float RotationOffset = 0;

    private bool ExitAnimIsLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        this.RotationOffset = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (!this.ExitAnimIsLoading)
        {
            return;
        }
        OpenExit();
    }

    public void OpenExit()
    {
        ExitAnimIsLoading = true;
        
        Vector3 targetPosition = new Vector3(PointOne.position.x, PlayerTransform.position.y, PointOne.position.z);

        float step = 10 * Time.deltaTime;
        PlayerTransform.position = Vector3.MoveTowards(PlayerTransform.position, PointOne.position, step);

        // Überprüfe, ob das Objekt den Ziel-Punkt erreicht hat
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(targetPosition.x, targetPosition.z)) > 0.1f)
        {
            return;
        }

        
        Quaternion targetRotation = new Quaternion();


        targetRotation = Quaternion.Euler(0, RotationOffset + -90, 0);


        this.DoorTransform.rotation = Quaternion.RotateTowards(DoorTransform.rotation, targetRotation,
            Time.deltaTime * 20f);

        if (DoorTransform.rotation != targetRotation) return;
    }
}