using UnityEngine;

public class RandomEmissionColorLerper : MonoBehaviour
{
    public float duration = 1.0f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.0f;

    private float timeElapsed = 0.0f;
    private Color startColor;
    private Color endColor;

    private Renderer renderer;

    //private ColorLerper colorLerp; 

    private void Start()
    {
        // Get the renderer component of the object this script is attached to
        renderer = GetComponent<Renderer>();
        //colorLerp = GetComponent<ColorLerper>();

        // Set the start color to the current emission color of the material
        startColor = renderer.material.GetColor("_EmissionColor");
        //startColor = colorLerp.startColor;

        // Set the end color to a random color with a random intensity between minIntensity and maxIntensity
        endColor = Random.ColorHSV(0.0f, 1.0f, 1.0f, 1.0f, minIntensity, maxIntensity);
        //endColor = colorLerp.endColor;

    }

    private void Update()
    {
        // Increment the time elapsed since the script started
        timeElapsed += Time.deltaTime;

        // Calculate the current color based on the elapsed time and duration
        float t = Mathf.Clamp01(timeElapsed / duration);
        Color currentColor = Color.Lerp(startColor, endColor, t);

        // Update the emission color of the material
        renderer.material.SetColor("_EmissionColor", currentColor);

        // If we've reached the end color, generate a new random end color and reset the time elapsed to 0
        if (t == 1.0f)
        {
            timeElapsed = 0.0f;
            startColor = endColor;
            endColor = Random.ColorHSV(0.0f, 1.0f, 1.0f, 1.0f, minIntensity, maxIntensity);
            //startColor = colorLerp.startColor;
            //endColor = colorLerp.endColor; 
        }
    }
}