using Mono.Cecil.Cil;
using NUnit.Framework;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class FadeScript : MonoBehaviour
{
    private SpriteRenderer black;
    private float alp = 0;

    void Awake()
    {
        // Get the SpriteRenderer component
        black = GetComponent<SpriteRenderer>();

        // Validate that the component exists
        if (black == null){}
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GearScript.isPressed == true)
        {
            alp += Time.deltaTime * 1.5f;
        }
        SetOpacity(alp);
    }
    public void SetOpacity(float alpha)
    {
        if (black == null) return;

        // Clamp alpha to valid range
        alpha = Mathf.Clamp01(alpha);

        // Get current color and change only the alpha
        Color color = black.color;
        color.a = alpha;
        black.color = color;
    }
}
