using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Texture[] textures;

    private int animationSteps;

    [SerializeField] private float fps = 30f;

    private float fpsCounter;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        fpsCounter += Time.deltaTime;
        if(fpsCounter >= 1f / fps)
        {
            animationSteps++;
            if (animationSteps > textures.Length)
                animationSteps = 0;
            lineRenderer.material.SetTexture("_MainText", textures[animationSteps]);
            fpsCounter = 0;
        }
    }
}
