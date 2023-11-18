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
        if (hit.collider && GameManager.Instance.lightingOn)
        {
            infoText.gameObject.SetActive(true);
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.CompareTag("RedKey"))
            {
                GameManager.Instance.pickedUpRedKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }
            else if (hit.collider.CompareTag("GreenKey"))
            {
                GameManager.Instance.pickedUpGreenKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }
            else if (hit.collider.CompareTag("BlueKey"))
            {
                GameManager.Instance.pickedUpBlueKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }
            else if (hit.collider.CompareTag("TutKey"))
            {
                GameManager.Instance.pickedUpTutKey = true;
                hit.collider.gameObject.SetActive(false);
                return;
            }
        }
    }
}
