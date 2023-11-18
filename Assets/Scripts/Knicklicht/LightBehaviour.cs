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

    public float lightDiminish = 0.1f;
    public float emissionIntensity = 1f;

    public Light point;
    public Color temp;
    public Material lightMat;

    private void Start()
    {
        point = GetComponent<Light>();
        Renderer renderer = GetComponent<Renderer>();
        if(renderer != null)
        {
            lightMat = renderer.material;
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            activeTimer -= Time.deltaTime;
            point.intensity -= lightDiminish * Time.deltaTime;
            StartCoroutine(DecreaseEmissionOverTime(activeTimer, lightDiminish));

            if (activeTimer <= 0)
            {
                activeTimer = 10f;
                point.intensity = 1;
                gameObject.SetActive(false);
                GameManager.Instance.lightingOn = false;
            }
        }
    }

    public void OnKnickLicht(InputAction.CallbackContext ctx)
    {
        if(ctx.started && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            GameManager.Instance.lightingOn = true;
            RandomColor();
        }
    }

    private void RandomColor()
    {
        ranGreen = Random.Range(0.5f,1f);
        ranBlue = Random.Range(0.5f, 1f);
        ranRed = Random.Range(0.5f, 1f);
        temp = new Color(ranRed, ranGreen, ranBlue);
        SetEmission(temp * emissionIntensity);
        point.color = new Color(ranRed, ranGreen, ranBlue);
    }

    void SetEmission(Color color)
    {
        lightMat.EnableKeyword("_EMISSION");

        lightMat.SetColor("_EmissionColor", color);
    }

    IEnumerator DecreaseEmissionOverTime(float duration, float decreaseRate)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            emissionIntensity -= decreaseRate;
            if (emissionIntensity < 0f)
            {
                emissionIntensity = 0f;
            }

            SetEmission(temp * emissionIntensity);

            elapsedTime += 1f; // Decrease by 1 second
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // Ensure emission is completely off at the end
        SetEmission(Color.black);
    }
}
