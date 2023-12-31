using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.InputSystem;

public class sonar : MonoBehaviour
{
    [SerializeField]
    private SoundRequestCollection requests;
    [SerializeField]
    private AudioData thanos;

    public float sonarSpeed = 5f;
    public float sonarRadius = 5f;

    public bool canSonar;

    public LayerMask detectionLayer;

    void Update()
    {
        if (canSonar)
        {
            EmitSonarWaves();
        }
    }

    void EmitSonarWaves()
    {
        float step = sonarSpeed * Time.deltaTime;
        // Emit sonar waves in a circular pattern
        for (float angle = 0; angle < 360; angle += step)
        {
            float radians = Mathf.Deg2Rad * angle;
            Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
            Vector3 startPosition = transform.position;

            // Move the starting position outside the player to avoid self-detection
            startPosition += direction * 0.1f;

            RaycastHit hit;

            // Cast a ray to detect objects
            if (Physics.Raycast(startPosition, direction, out hit, sonarRadius, detectionLayer))
            {
                Debug.Log("Etwas wurde gefunden");
                // Object detected, handle the detection (outline or other effects)
                OnObjectDetected(hit.collider.gameObject);
            }
        }
    }

    void OnObjectDetected(GameObject detectedObject)
    {
        // Implement the logic to handle the detected object
        // For example, you can trigger an outline effect on the detected object
        if (!detectedObject)
        {
            return;
        }
        detectedObject.GetComponent<Outline>().enabled = true;
    }

    public void CastSonar(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            canSonar = true;
            requests.Add(SoundRequest.Request(true, thanos));
        }
        else if(ctx.canceled)
        {
            canSonar = false;
        }
    }
}
