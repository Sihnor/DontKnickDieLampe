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
        Physics.Raycast(cam.transform.position, cam.transform.rotation.eulerAngles, out hit, rayLeangth, keyLayer);
        if(hit.collider.gameObject != null)
        {
            infoText.gameObject.SetActive(true);
        }
        else
        {
            infoText.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown(KeyCode.Mouse0.ToString()))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "RedKey":
                    {
                        GameManager.Instance.pickedUpRedKey = true;
                        return;
                    }

                case "GreenKey":
                    {
                        GameManager.Instance.pickedUpGreenKey = true;
                        return;
                    }

                case "BlueKey":
                    {
                        GameManager.Instance.pickedUpBlueKey = true;
                        return;
                    }
            }
            Destroy(hit.collider.gameObject);
        }
    }
}
