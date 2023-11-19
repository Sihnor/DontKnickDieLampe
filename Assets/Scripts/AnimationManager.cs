using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }

    [SerializeField] private Transform DoorTransform;
    [SerializeField] private Transform PlayerTransForm;
    [SerializeField] private Transform PointOne;
    private bool IsPointOneReached = false;
    [SerializeField] private Transform PointTwo;

    private bool IsDoorOpen = false;
    private bool IsExitPlaying = false;

    [SerializeField] private Animator TutLockAnimation;
    [SerializeField] private GameObject TutLock;
    [SerializeField] private GameObject EnemyOne;
    [SerializeField] private GameObject EnemyTwo;
    [SerializeField] private GameObject Light;
    
    public void StartUnlockAnimation()
    {
        this.TutLockAnimation.SetBool("PlayUnlockAnimation", true);
        Invoke("DisableLock", 10f);
    }

    public void StartExitAnimation()
    {
        this.IsExitPlaying = true;
        Quaternion targetRotation = new Quaternion();


        targetRotation = Quaternion.Euler(0, 90, 0);


        this.DoorTransform.rotation = Quaternion.RotateTowards(DoorTransform.rotation, targetRotation,
            Time.deltaTime * 50);

        if (DoorTransform.rotation != targetRotation) return;

        // Walk to Point One
        float speed = 2.0f;

        float step = speed * Time.deltaTime;

        Vector3 targetPosition = new Vector3(PointOne.position.x, PlayerTransForm.position.y, PointOne.position.z);

        if (!this.IsPointOneReached)
        {
            PlayerTransForm.position = Vector3.MoveTowards(PlayerTransForm.position, targetPosition, step);    
        }

        // Überprüfe, ob das Objekt den Ziel-Punkt erreicht hat
        if (Vector3.Distance(new Vector2(PlayerTransForm.position.x, PlayerTransForm.position.z),
                new Vector2(targetPosition.x, targetPosition.z)) < 0.9f || this.IsPointOneReached)
        {
            this.IsPointOneReached = true;
        }

        if (!this.IsPointOneReached)
        {
            return;
        }

        targetPosition = new Vector3(PointTwo.position.x, PlayerTransForm.position.y, PointTwo.position.z);
        // Walk to Point OnTwo
        PlayerTransForm.position = Vector3.MoveTowards(PlayerTransForm.position, targetPosition, step);
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

    private void Update()
    {
        if (!this.IsDoorOpen && this.IsExitPlaying)
        {
            StartExitAnimation();
        }
    }

    private void DisableLock()
    {
        this.TutLock.SetActive(false);
        this.EnemyOne.SetActive(true);
        this.EnemyTwo.SetActive(true);
        this.Light.SetActive(false);
    }
}