using System;
using UnityEngine;
using UnityEngine.AI;

public enum EEnemyState
{
    Idle,
    Chasing
}

public class MovePattern : MonoBehaviour
{
    [SerializeField, Header("AI")] public Transform[] MovePoints = new Transform[6];
    private NavMeshAgent Navigation;
    private Int32 MovePointIndex = 0;

    // TODO muss noch angeaendert werden zu dem richtigen spieler
    public GameObject Player;


    private EEnemyState CurrentState = EEnemyState.Idle;

    // Start is called before the first frame update
    private void Start()
    {
        this.Navigation = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        switch (this.CurrentState)
        {
            case EEnemyState.Idle:
                this.IdleState();
                break;
            case EEnemyState.Chasing:
                this.ChaseState();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SetState(EEnemyState _newState)
    {
        this.CurrentState = _newState;
    }

    private void IdleState()
    {
        if (!this.Navigation.pathPending && this.Navigation.remainingDistance < 0.5f)
        {
            this.GoToNextPoint();
        }
    }

    private void ChaseState()
    {
        this.Navigation.destination = Player.transform.position;
    }

    private void GoToNextPoint()
    {
        this.MovePointIndex++;

        if (this.MovePointIndex == this.MovePoints.Length)
        {
            this.MovePointIndex = 0;
        }

        this.Navigation.destination = this.MovePoints[this.MovePointIndex].position;
    }
}