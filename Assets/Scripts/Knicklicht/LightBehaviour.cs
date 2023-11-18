using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightBehaviour : MonoBehaviour
{
    public float activeTimer = 10f;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            activeTimer -= Time.deltaTime;

            if (activeTimer <= 0)
            {
                activeTimer = 5f;
                gameObject.SetActive(false);
            }
        }
    }

    public void OnKnickLicht(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            gameObject.SetActive(true);
        }
    }
}
