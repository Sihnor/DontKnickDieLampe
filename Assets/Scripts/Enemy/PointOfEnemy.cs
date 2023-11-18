using UnityEngine;
using UnityEngine.Serialization;

public class PointOfEnemy : MonoBehaviour
{
    [SerializeField, Header("FieldView")] public int FieldOfViewDegree = 90;
    [FormerlySerializedAs("LengthOfSight")] public float DistanceOfSight;
    [SerializeField, Range(3, 100)] public int NumberOfRays;

    private MovePattern EnemyMovement;

    private void Start()
    {
        EnemyMovement = GetComponent<MovePattern>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!GameManager.Instance.lightingOn)
        {
            return;
        }

        float startOfView = this.FieldOfViewDegree / -2;

        Vector3 currentPosition = this.transform.position;

        int distanceBetweenRays = this.FieldOfViewDegree / this.NumberOfRays;
        
        for (int i = 0; i < this.NumberOfRays; i++)
        {
            for (int j = 0; j < this.NumberOfRays; j++)
            {
                Vector3 temp = Quaternion.Euler(startOfView + j * distanceBetweenRays,
                    startOfView + i * distanceBetweenRays,0) * this.transform.forward;
                
                RaycastHit hit;
                if (Physics.Raycast(currentPosition, temp, out hit, this.DistanceOfSight))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        Debug.DrawLine(currentPosition, currentPosition + (temp * hit.distance), Color.red);
                        GameManager.Instance.PlayerIsChased = true;
                        EnemyMovement.SetState(EEnemyState.Chasing);
                        return;
                    }
                }
                Debug.DrawLine(currentPosition, currentPosition + (temp * this.DistanceOfSight), Color.green);
            }
        }
        this.EnemyMovement.SetState(EEnemyState.Idle);
        GameManager.Instance.PlayerIsChased = false;
    }
}
