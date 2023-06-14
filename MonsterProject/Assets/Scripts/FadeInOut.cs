using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] float fadeSpeed;
    [SerializeField] float fadeAmount;

    float initialOpacity;
    Material mat;

    public bool doFade;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        initialOpacity = mat.color.a;
    }

    private void Update()
    {
        if (doFade)
        {
            FadeNow();
        }
        else
        {
            ResetFade();
        }
    }

    private void ResetFade()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, initialOpacity, fadeSpeed));
        mat.color = smoothColor;
    }

    private void FadeNow()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed));
        mat.color = smoothColor;
    }
}