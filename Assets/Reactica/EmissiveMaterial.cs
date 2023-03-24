using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveMaterial : MonoBehaviour
{

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>(); 
    }


    // An example to update the emission color & intensity (and albedo) every frame.
    void Update()
    {
        RendererExtensions.UpdateGIMaterials(renderer);
    }
}
