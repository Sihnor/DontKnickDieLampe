using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightBehaviour : MonoBehaviour
{
    public float activeTimer = 10f;

    public float ranGreen;
    public float ranBlue;
    public float ranRed;

    public Light point;

    //public Material lightMat;

    private void Start()
    {
        point = GetComponent<Light>();
    }

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
            RandomColor();
        }
    }

    private void RandomColor()
    {
        ranGreen = Random.value;
        ranBlue = Random.value;
        ranRed = Random.value;
        //lightMat.color = new Color(ranRed, ranGreen, ranBlue);
        //point.color = lightMat.color;
        point.color = new Color(ranRed, ranGreen, ranBlue);
    }
}
