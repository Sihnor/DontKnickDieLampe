using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastOutline : MonoBehaviour
{
    private Material outlineMaterial;
    private Material originalMaterial;
    private bool isOutlined = false;

    void Start()
    {
        // Create a copy of the original material
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void ToggleOutline()
    {
        // Check if the object is already outlined
        if (isOutlined)
        {
            // Restore the original material
            GetComponent<Renderer>().material = originalMaterial;
        }
        else
        {
            // Create an instance of the outline material
            if (outlineMaterial == null)
            {
                outlineMaterial = new Material(originalMaterial);
                outlineMaterial.shader = Shader.Find("Standard");
                outlineMaterial.SetFloat("_Outline", 0.002f); // Adjust the outline width
                outlineMaterial.SetColor("_OutlineColor", Color.green); // Adjust the outline color
            }

            // Apply the outline material
            GetComponent<Renderer>().material = outlineMaterial;
        }

        // Toggle the outline state
        isOutlined = !isOutlined;
    }
}
