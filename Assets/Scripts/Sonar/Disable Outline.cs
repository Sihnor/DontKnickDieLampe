using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOutline : MonoBehaviour
{
    public float visibilityTimer = 5f;

    private void Update()
    {
        if (gameObject.GetComponent<Outline>().enabled)
        {
            visibilityTimer -= Time.deltaTime;

            if(visibilityTimer <= 0)
            {
                visibilityTimer = 5f;
                gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
