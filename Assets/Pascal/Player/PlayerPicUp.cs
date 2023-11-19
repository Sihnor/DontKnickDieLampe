using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPicUp : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float rayLeangth;
    [SerializeField] LayerMask keyLayer;
    [SerializeField] TextMeshProUGUI infoText;

    RaycastHit hit;
    void Start()
    {
        infoText.gameObject.SetActive(false);
    }

    void Update()
    {
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayLeangth, keyLayer);
        Debug.DrawLine(cam.transform.position, hit.point, Color.black);

        //Debug.Log(hit.colliderInstanceID);
        if (hit.collider && GameManager.Instance.lightingOn)
        {
            infoText.gameObject.SetActive(true);
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.lightingOn)
        {
            if (hit.collider == null)
            {
                return;
            }

            if (hit.collider.CompareTag("RedKey"))
            {
                GameManager.Instance.PickedUpRedKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }

            if (hit.collider.CompareTag("GreenKey"))
            {
                GameManager.Instance.PickedUpGreenKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }

            if (hit.collider.CompareTag("BlueKey"))
            {
                GameManager.Instance.PickedUpBlueKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }

            if (hit.collider.CompareTag("TutKey"))
            {
                GameManager.Instance.PickedUpTutKey = true;
                hit.collider.gameObject.SetActive(false);
                AnimationManager.Instance.StartUnlockAnimation();
                return;
            }
            if (hit.collider.CompareTag("EscapeDoor"))
            {
                if (GameManager.Instance.DoorUnlocked)
                {
                    Debug.Log("Die Tuer ist offen");
                    AnimationManager.Instance.StartExitAnimation();
                    return;
                }
            }
        }
    }
}
