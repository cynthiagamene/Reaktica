using UnityEngine;

public class EmissionColorSetter : MonoBehaviour
{
    public Color emissionColor;

    private Renderer renderer;

    private void Start()
    {
        // Get the renderer component of the object this script is attached to
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Set the emission color of the material to the specified color
        renderer.material.SetColor("_EmissionColor", emissionColor);
    }
}