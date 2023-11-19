using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject cam;
    Rigidbody rb;

    [SerializeField] float sprintSpeedToAdd = 5;
    [SerializeField] float speed = 10;

    [SerializeField] private int health = 3;

    [SerializeField]
    private SoundRequestCollection requests;
    [SerializeField]
    private AudioData footSteps;

    [SerializeField] float sprintTime = 10;
    [SerializeField] float sprintTimeIncrease = 1;
    [SerializeField] float sprintTimeDecrease = 2;
    float curSprintTime;
    bool onCooldown = false;

    [SerializeField] float sensiX = 0.1f;
    [SerializeField] float sensiY = 0.1f;
    [SerializeField] int clampValue = 225;


    [SerializeField] float sinTime = 0f;
    [SerializeField] float sinOffset = 0.1f;
    [SerializeField] float sinFrequenz = 0.1f;
    [SerializeField] float sinAmplitude = 0.1f;

    Vector2 moveInput;
    Vector3 direction;
    Vector2 mouseInput;
    Vector3 rotationVecPlayer;
    Vector3 rotationVecCam;
    float sprintInput;

    void Start()
    {
        sensiX = GameManager.Instance.xSensitivity;
        sensiY = GameManager.Instance.ySensitivity;
        rb = GetComponent<Rigidbody>();
        cam = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(3);
            return;
        }
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

        if (curSprintTime < 0)
        {
            curSprintTime = 0;
            onCooldown = false;
        }

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            if (Time.frameCount % 180 == 0)
            {
                requests.Add(SoundRequest.Request(true, footSteps));
            }
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + sinAmplitude * (Mathf.Sin(sinFrequenz * sinTime) + sinOffset), cam.transform.position.z);
            sinTime += 1f * Time.deltaTime;
        }

        direction = moveInput.x * transform.right + moveInput.y * transform.forward;
        rb.AddForce(direction * (speed + (sprintSpeedToAdd * sprintInput)) * Time.deltaTime * 100);
        transform.rotation = Quaternion.Euler(rotationVecPlayer * sensiX);
        cam.transform.rotation = Quaternion.Euler(new Vector3(rotationVecCam.x, rotationVecPlayer.y, 0) * sensiY);
    }
    public int getHealth()
    {
        return health;
    }
    public void dealDamage(int _damage)
    {
        health -= _damage;
        if (health < 0)
        {
            health = 0;
        }
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
