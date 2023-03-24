using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float duration = 1.0f;

    private float timeElapsed = 0.0f;

    private void Update()
    {
        // Increment the time elapsed since the script started
        timeElapsed += Time.deltaTime;

        // Calculate the current color based on the elapsed time and duration
        float t = Mathf.Clamp01(timeElapsed / duration);
        Color currentColor = Color.Lerp(startColor, endColor, t);

        // Update the color of the object this script is attached to
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = currentColor;

        // If we've reached the end color, reset the time elapsed to 0
        if (t == 1.0f)
        {
            timeElapsed = 0.0f;
            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
        }
    }
}