using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameObject cam;
    Rigidbody rb;

    [SerializeField] float sprintSpeedToAdd = 5;
    [SerializeField] float speed = 10;

    [SerializeField] float sprintTime = 10;
    [SerializeField] float sprintTimeIncrease = 1;
    [SerializeField] float sprintTimeDecrease = 2;
    float curSprintTime;
    bool onCooldown = false;

    [SerializeField] float sensiX = 0.1f;
    [SerializeField] float sensiY = 0.1f;
    [SerializeField] int clampValue = 225;

    Vector2 moveInput;
    Vector3 direction;
    Vector2 mouseInput;
    Vector3 rotationVecPlayer;
    Vector3 rotationVecCam;
    float sprintInput;

    void Start()
    {
        //sensiX = GameManager.Instance.xSensitivity;
        //sensiY = GameManager.Instance.ySensitivity;
        rb = GetComponent<Rigidbody>();
        cam = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (curSprintTime < sprintTime && sprintInput == 1 && !onCooldown)
        {
            curSprintTime += sprintTimeIncrease * Time.deltaTime;
        }
        else
        {
            onCooldown = true;
            sprintInput = 0;
            curSprintTime -= sprintTimeDecrease * Time.deltaTime;
        }

        if(curSprintTime < 0)
        {
            curSprintTime = 0;
            onCooldown = false;
        }
        direction = moveInput.x * transform.right + moveInput.y * transform.forward;
        rb.AddForce(direction * (speed + (sprintSpeedToAdd * sprintInput)) * Time.deltaTime * 100);
        transform.rotation = Quaternion.Euler(rotationVecPlayer * sensiX);
        cam.transform.rotation = Quaternion.Euler(new Vector3(rotationVecCam.x, rotationVecPlayer.y, 0) * sensiY);
    }

    public void OnMoveInput(InputAction.CallbackContext _input)
    {
        if (!GameManager.Instance.paused)
        {
            moveInput = _input.ReadValue<Vector2>();
        }
    }
    public void OnSprintInput(InputAction.CallbackContext _input)
    {
        if (!GameManager.Instance.paused && !onCooldown)
        {
            sprintInput = _input.ReadValue<float>();
        }
    }

    public void OnMouseInput(InputAction.CallbackContext _input)
    {
        if (!GameManager.Instance.paused)
        {
            mouseInput = _input.ReadValue<Vector2>();
            rotationVecCam.x -= mouseInput.y;
            rotationVecCam.x = Mathf.Clamp(rotationVecCam.x, -clampValue, clampValue);
            rotationVecPlayer.y += mouseInput.x;
        }
    }
}
